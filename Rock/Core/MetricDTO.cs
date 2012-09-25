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
	/// Data Transfer Object for Metric object
	/// </summary>
	public partial class MetricDto : IDto
	{

#pragma warning disable 1591
		public bool IsSystem { get; set; }
		public bool Type { get; set; }
		public string Category { get; set; }
		public string Title { get; set; }
		public string Subtitle { get; set; }
		public string Description { get; set; }
		public int? MinValue { get; set; }
		public int? MaxValue { get; set; }
		public int CollectionFrequencyId { get; set; }
		public DateTime? LastCollected { get; set; }
		public string Source { get; set; }
		public string SourceSQL { get; set; }
		public int Order { get; set; }
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
		public MetricDto ()
		{
		}

		/// <summary>
		/// Instantiates a new DTO object from the model
		/// </summary>
		/// <param name="metric"></param>
		public MetricDto ( Metric metric )
		{
			CopyFromModel( metric );
		}

		/// <summary>
		/// Copies the model property values to the DTO properties
		/// </summary>
		/// <param name="metric"></param>
		public void CopyFromModel( IModel model )
		{
			if ( model is Metric )
			{
				var metric = (Metric)model;
				this.IsSystem = metric.IsSystem;
				this.Type = metric.Type;
				this.Category = metric.Category;
				this.Title = metric.Title;
				this.Subtitle = metric.Subtitle;
				this.Description = metric.Description;
				this.MinValue = metric.MinValue;
				this.MaxValue = metric.MaxValue;
				this.CollectionFrequencyId = metric.CollectionFrequencyId;
				this.LastCollected = metric.LastCollected;
				this.Source = metric.Source;
				this.SourceSQL = metric.SourceSQL;
				this.Order = metric.Order;
				this.CreatedDateTime = metric.CreatedDateTime;
				this.ModifiedDateTime = metric.ModifiedDateTime;
				this.CreatedByPersonId = metric.CreatedByPersonId;
				this.ModifiedByPersonId = metric.ModifiedByPersonId;
				this.Id = metric.Id;
				this.Guid = metric.Guid;
			}
		}

		/// <summary>
		/// Copies the DTO property values to the model properties
		/// </summary>
		/// <param name="metric"></param>
		public void CopyToModel ( IModel model )
		{
			if ( model is Metric )
			{
				var metric = (Metric)model;
				metric.IsSystem = this.IsSystem;
				metric.Type = this.Type;
				metric.Category = this.Category;
				metric.Title = this.Title;
				metric.Subtitle = this.Subtitle;
				metric.Description = this.Description;
				metric.MinValue = this.MinValue;
				metric.MaxValue = this.MaxValue;
				metric.CollectionFrequencyId = this.CollectionFrequencyId;
				metric.LastCollected = this.LastCollected;
				metric.Source = this.Source;
				metric.SourceSQL = this.SourceSQL;
				metric.Order = this.Order;
				metric.CreatedDateTime = this.CreatedDateTime;
				metric.ModifiedDateTime = this.ModifiedDateTime;
				metric.CreatedByPersonId = this.CreatedByPersonId;
				metric.ModifiedByPersonId = this.ModifiedByPersonId;
				metric.Id = this.Id;
				metric.Guid = this.Guid;
			}
		}
	}
}
