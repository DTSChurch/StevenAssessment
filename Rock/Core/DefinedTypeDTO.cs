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

using Rock.Data;

namespace Rock.Core
{
	/// <summary>
	/// Data Transfer Object for DefinedType object
	/// </summary>
	public partial class DefinedTypeDto : IDto
	{

#pragma warning disable 1591
		public bool IsSystem { get; set; }
		public int? FieldTypeId { get; set; }
		public int Order { get; set; }
		public string Category { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? CreatedDateTime { get; set; }
		public DateTime? ModifiedDateTime { get; set; }
		public int? CreatedByPersonId { get; set; }
		public int? ModifiedByPersonId { get; set; }
		public int Id { get; set; }
		public Guid Guid { get; set; }
#pragma warning restore 1591

		/// <summary>
		/// Instantiates a new DTO object
		/// </summary>
		public DefinedTypeDto ()
		{
		}

		/// <summary>
		/// Instantiates a new DTO object from the model
		/// </summary>
		/// <param name="definedType"></param>
		public DefinedTypeDto ( DefinedType definedType )
		{
			CopyFromModel( definedType );
		}

		/// <summary>
		/// Copies the model property values to the DTO properties
		/// </summary>
		/// <param name="definedType"></param>
		public void CopyFromModel( IModel model )
		{
			if ( model is DefinedType )
			{
				var definedType = (DefinedType)model;
				this.IsSystem = definedType.IsSystem;
				this.FieldTypeId = definedType.FieldTypeId;
				this.Order = definedType.Order;
				this.Category = definedType.Category;
				this.Name = definedType.Name;
				this.Description = definedType.Description;
				this.CreatedDateTime = definedType.CreatedDateTime;
				this.ModifiedDateTime = definedType.ModifiedDateTime;
				this.CreatedByPersonId = definedType.CreatedByPersonId;
				this.ModifiedByPersonId = definedType.ModifiedByPersonId;
				this.Id = definedType.Id;
				this.Guid = definedType.Guid;
			}
		}

		/// <summary>
		/// Copies the DTO property values to the model properties
		/// </summary>
		/// <param name="definedType"></param>
		public void CopyToModel ( IModel model )
		{
			if ( model is DefinedType )
			{
				var definedType = (DefinedType)model;
				definedType.IsSystem = this.IsSystem;
				definedType.FieldTypeId = this.FieldTypeId;
				definedType.Order = this.Order;
				definedType.Category = this.Category;
				definedType.Name = this.Name;
				definedType.Description = this.Description;
				definedType.CreatedDateTime = this.CreatedDateTime;
				definedType.ModifiedDateTime = this.ModifiedDateTime;
				definedType.CreatedByPersonId = this.CreatedByPersonId;
				definedType.ModifiedByPersonId = this.ModifiedByPersonId;
				definedType.Id = this.Id;
				definedType.Guid = this.Guid;
			}
		}
	}
}
