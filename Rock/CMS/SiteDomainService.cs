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
using System.Linq;

using Rock.Data;

namespace Rock.Cms
{
	/// <summary>
	/// SiteDomain Service class
	/// </summary>
	public partial class SiteDomainService : Service<SiteDomain, SiteDomainDto>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="SiteDomainService"/> class
		/// </summary>
		public SiteDomainService()
			: base()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SiteDomainService"/> class
		/// </summary>
		public SiteDomainService(IRepository<SiteDomain> repository) : base(repository)
		{
		}

		/// <summary>
		/// Creates a new model
		/// </summary>
		public override SiteDomain CreateNew()
		{
			return new SiteDomain();
		}

		/// <summary>
		/// Query DTO objects
		/// </summary>
		/// <returns>A queryable list of DTO objects</returns>
		public override IQueryable<SiteDomainDto> QueryableDto( )
		{
			return QueryableDto( this.Queryable() );
		}

		/// <summary>
		/// Query DTO objects
		/// </summary>
		/// <returns>A queryable list of DTO objects</returns>
		public IQueryable<SiteDomainDto> QueryableDto( IQueryable<SiteDomain> items )
		{
			return items.Select( m => new SiteDomainDto()
				{
					IsSystem = m.IsSystem,
					SiteId = m.SiteId,
					Domain = m.Domain,
					CreatedDateTime = m.CreatedDateTime,
					ModifiedDateTime = m.ModifiedDateTime,
					CreatedByPersonId = m.CreatedByPersonId,
					ModifiedByPersonId = m.ModifiedByPersonId,
					Id = m.Id,
					Guid = m.Guid,				});
		}
	}
}
