/// Author: Ethan Widen
/// Email: ethan@dtschurch.com
/// Created Date: 4/8/2019

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web.UI.WebControls;
using Rock;
using Rock.Attribute;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;
using Rock.Web.UI;
using Rock.Web.UI.Controls;

[DisplayName("Birthdays/Anniversaries by Group")]
[Category("com_DTS > Birthdays & Anniversaries By Group Selection")]
[Description("See Birthdays and Anniversaries based on a multi-select of groups")]
[GroupTypesField("Group Types", "Group types to appear in the multi select", false)]
public partial class BirthdaysAndAnniversaries : RockBlock
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDropDown();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        groupMemberGrid.GridRebind += GroupMemberGrid_GridRebind;
    }

    private void GroupMemberGrid_GridRebind(object sender, GridRebindEventArgs e)
    {
        BindGrid();
    }

    private void BindDropDown()
    {
        if (!string.IsNullOrWhiteSpace(GetAttributeValue("GroupTypes")))
        {
            var groupTypeService = new GroupTypeService(new RockContext());
            List<String> groupTypeGuids = GetAttributeValue("GroupTypes").Split(',').ToList();
            List<int> groupTypeIds = groupTypeService.GetListByGuids(groupTypeGuids.Select(Guid.Parse).ToList()).Select(gt => gt.Id).ToList();
            gpGroups.IncludedGroupTypeIds = groupTypeIds;
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void btn_clear_birthday(object sender, EventArgs e)
    {
        ClearBirthday();
    }
    protected void btn_clear_anniv(object sender, EventArgs e)
    {
        ClearAnniversary();
    }
    private void ClearBirthday()
    {
        dateRangeFrom.SelectedIndex = 0;
        dateRangeTo.SelectedIndex = 0;

        BindGrid();
    }
    private void ClearAnniversary()
    {
        annDateRangeFrom.SelectedIndex = 0;
        annDateRangeTo.SelectedIndex = 0;
    }

    private void EnforceDateRanges()
    {
        // If either choice is "All" then change the other side of the range to all as well.
        if (dateRangeTo.SelectedIndex == 0 || dateRangeFrom.SelectedIndex == 0)
        {
            dateRangeTo.SelectedIndex = 0;
            dateRangeFrom.SelectedIndex = 0;
        }

        if (annDateRangeTo.SelectedIndex == 0 || annDateRangeFrom.SelectedIndex == 0)
        {
            annDateRangeTo.SelectedIndex = 0;
            annDateRangeFrom.SelectedIndex = 0;
        }

        // If the start date is set to be after the end date, just snap it to the
        // end date. Do this before applying filters to the groupMembers queryable.
        if (dateRangeTo.SelectedIndex > 0 && dateRangeFrom.SelectedIndex > dateRangeTo.SelectedIndex)
            dateRangeFrom.SelectedIndex = dateRangeTo.SelectedIndex;
        if (annDateRangeTo.SelectedIndex > 0 && annDateRangeFrom.SelectedIndex > annDateRangeTo.SelectedIndex)
            annDateRangeFrom.SelectedIndex = annDateRangeTo.SelectedIndex;
    }

    private void BindGrid()
    {
        var rockContext = new RockContext();
        var groupMemberService = new GroupMemberService(rockContext).Queryable().AsNoTracking();

        List<int> groupIdsMulti = gpGroups.SelectedValuesAsInt().ToList();
        var groupMembers = groupMemberService.Where(gm => groupIdsMulti.Contains(gm.GroupId));
        SortProperty sortProperty = groupMemberGrid.SortProperty;

        EnforceDateRanges();
        groupMembers = FilterByBirthday(groupMembers);

        Guid groupLocationTypeValueGuid = Rock.SystemGuid.DefinedValue.GROUP_LOCATION_TYPE_HOME.AsGuid();
        RockUdfHelper.AddressNamePart addressNamePart = RockUdfHelper.AddressNamePart.Full;

        string addressTypeId = DefinedValueCache.Get(groupLocationTypeValueGuid).Id.ToString();
        string addressComponent = addressNamePart.ConvertToString(false);

        if (sortProperty != null)
        {
            groupMemberGrid.DataSource = groupMembers.Select(gm => new MemberData()
            {
                FirstName = gm.Person.FirstName,
                LastName = gm.Person.LastName,
                Id = gm.Person.Id,
                BirthMonth = gm.Person.BirthMonth,
                BirthDay = gm.Person.BirthDay,
                BirthYear = gm.Person.BirthYear,
                Birthdate = gm.Person.BirthDate,
                AnniversaryMonth = gm.Person.AnniversaryDate.HasValue ? gm.Person.AnniversaryDate.Value.Month : (int?)null,
                AnniversaryDay = gm.Person.AnniversaryDate.HasValue ? gm.Person.AnniversaryDate.Value.Day : (int?)null,
                AnniversaryYear = gm.Person.AnniversaryDate.HasValue ? gm.Person.AnniversaryDate.Value.Year : (int?)null,
                Anniversary = gm.Person.AnniversaryDate,
                Email = gm.Person.Email,
                Address = RockUdfHelper.ufnCrm_GetAddress(gm.Person.Id, addressTypeId, addressComponent)
            }).Distinct().Sort(sortProperty).ToList();
        }
        else
        {
            groupMemberGrid.DataSource = groupMembers.Select(gm => new MemberData()
            {
                FirstName = gm.Person.FirstName,
                LastName = gm.Person.LastName,
                Id = gm.Person.Id,
                BirthMonth = gm.Person.BirthMonth,
                BirthDay = gm.Person.BirthDay,
                BirthYear = gm.Person.BirthYear,
                Birthdate = gm.Person.BirthDate,
                AnniversaryMonth = gm.Person.AnniversaryDate.HasValue ? gm.Person.AnniversaryDate.Value.Month : (int?)null,
                AnniversaryDay = gm.Person.AnniversaryDate.HasValue ? gm.Person.AnniversaryDate.Value.Day : (int?)null,
                AnniversaryYear = gm.Person.AnniversaryDate.HasValue ? gm.Person.AnniversaryDate.Value.Year : (int?)null,
                Anniversary = gm.Person.AnniversaryDate,
                Email = gm.Person.Email,
                Address = RockUdfHelper.ufnCrm_GetAddress(gm.Person.Id, addressTypeId, addressComponent)
            }).Distinct().OrderBy(s => s.FirstName).ToList();
        }

        groupMemberGrid.DataBind();
    }

    /// <summary>
    /// Applies filters to group members queryable.
    /// </summary>
    /// <param name="groupMembers">The group members.</param>
    private IQueryable<GroupMember> FilterByBirthday(IQueryable<GroupMember> groupMembers)
    {
        // Dynamically build our query based on whether or not the date range selectors have values.
        //
        // Indices
        // ________________
        // 0:       All
        // 1-12:    Jan-Dec
        if (dateRangeFrom.SelectedIndex > 0)
        {
            var dateRangeFromMonth = int.Parse(dateRangeFrom.SelectedValue);
            groupMembers = groupMembers.Where(gm => gm.Person.BirthMonth >= dateRangeFromMonth);
        }

        if (dateRangeTo.SelectedIndex > 0)
        {
            var dateRangeToMonth = int.Parse(dateRangeTo.SelectedValue);
            groupMembers = groupMembers.Where(gm => gm.Person.BirthMonth <= dateRangeToMonth);
        }

        if (annDateRangeFrom.SelectedIndex > 0)
        {
            var annDateRangeFromMonth = int.Parse(annDateRangeFrom.SelectedValue);
            groupMembers = groupMembers.Where(gm => gm.Person.AnniversaryDate.Value.Month >= annDateRangeFromMonth);
        }

        if (annDateRangeTo.SelectedIndex > 0)
        {
            var annDateRangeToMonth = int.Parse(annDateRangeTo.SelectedValue);
            groupMembers = groupMembers.Where(gm => gm.Person.AnniversaryDate.Value.Month <= annDateRangeToMonth);
        }

        return groupMembers;
    }

    protected void groupMemberGrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        BindGrid();
    }

    protected void gmFilters_ApplyFilterClick(object sender, EventArgs e)
    {
        gmFilters.SaveUserPreference("gmBirthdayDateRange", "Birthday Date Range", gmBirthdayDateRange.DelimitedValues );
        gmFilters.SaveUserPreference("gmAnniversaryDateRange", "Anniversary Date Range", gmAnniversaryDateRange.DelimitedValues );
        BindGrid();
    }
}

internal class MemberData
{
    public string FirstName { get; set; }
    public int Id { get; internal set; }
    public DateTime? Birthdate { get; internal set; }
    public DateTime? Anniversary { get; internal set; }
    public int? BirthMonth { get; internal set; }
    public int? BirthDay { get; internal set; }
    public int? BirthYear { get; internal set; }
    public int? AnniversaryMonth { get; internal set; }
    public int? AnniversaryDay { get; internal set; }
    public int? AnniversaryYear { get; internal set; }
    public string Email { get; internal set; }
    public string Address { get; internal set; }
    public string LastName { get; internal set; }

    public MemberData()
    {
    }
}