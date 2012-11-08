//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;

using Rock.Data;

namespace Rock.Crm
{
    /// <summary>
    /// Data Transfer Object for GroupType object
    /// </summary>
    [Serializable]
    [DataContract]
    public partial class GroupTypeDto : IDto
    {
        /// <summary />
        [DataMember]
        public bool IsSystem { get; set; }

        /// <summary />
        [DataMember]
        public string Name { get; set; }

        /// <summary />
        [DataMember]
        public string Description { get; set; }

        /// <summary />
        [DataMember]
        public int? DefaultGroupRoleId { get; set; }

        /// <summary />
        [DataMember]
        public int Id { get; set; }

        /// <summary />
        [DataMember]
        public Guid Guid { get; set; }

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public GroupTypeDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="groupType"></param>
        public GroupTypeDto ( GroupType groupType )
        {
            CopyFromModel( groupType );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "IsSystem", this.IsSystem );
            dictionary.Add( "Name", this.Name );
            dictionary.Add( "Description", this.Description );
            dictionary.Add( "DefaultGroupRoleId", this.DefaultGroupRoleId );
            dictionary.Add( "Id", this.Id );
            dictionary.Add( "Guid", this.Guid );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public virtual dynamic ToDynamic()
        {
            dynamic expando = new ExpandoObject();
            expando.IsSystem = this.IsSystem;
            expando.Name = this.Name;
            expando.Description = this.Description;
            expando.DefaultGroupRoleId = this.DefaultGroupRoleId;
            expando.Id = this.Id;
            expando.Guid = this.Guid;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyFromModel( IEntity model )
        {
            if ( model is GroupType )
            {
                var groupType = (GroupType)model;
                this.IsSystem = groupType.IsSystem;
                this.Name = groupType.Name;
                this.Description = groupType.Description;
                this.DefaultGroupRoleId = groupType.DefaultGroupRoleId;
                this.Id = groupType.Id;
                this.Guid = groupType.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is GroupType )
            {
                var groupType = (GroupType)model;
                groupType.IsSystem = this.IsSystem;
                groupType.Name = this.Name;
                groupType.Description = this.Description;
                groupType.DefaultGroupRoleId = this.DefaultGroupRoleId;
                groupType.Id = this.Id;
                groupType.Guid = this.Guid;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class GroupTypeDtoExtension
    {
        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static GroupType ToModel( this GroupTypeDto value )
        {
            GroupType result = new GroupType();
            value.CopyToModel( result );
            return result;
        }

        /// <summary>
        /// To the model.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<GroupType> ToModel( this List<GroupTypeDto> value )
        {
            List<GroupType> result = new List<GroupType>();
            value.ForEach( a => result.Add( a.ToModel() ) );
            return result;
        }

        /// <summary>
        /// To the dto.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<GroupTypeDto> ToDto( this List<GroupType> value )
        {
            List<GroupTypeDto> result = new List<GroupTypeDto>();
            value.ForEach( a => result.Add( new GroupTypeDto( a ) ) );
            return result;
        }
    }
}