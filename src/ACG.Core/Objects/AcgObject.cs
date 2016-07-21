using System;
using System.Collections.Generic;
using System.Text;

using GeoAPI.Geometries;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents base class for any AreaCAD-GIS object.
    /// </summary>
    public abstract class AcgObject : IAcgObject
    {
        /// <inheritdoc/>
        public AcgObject()
        {
            this.GUID = Guid.NewGuid();
            this.ForeignKey = 0;
            this.Status = 0;
            this.DataSourceAuthority = "";
            this.DataSourceAuthor = "";
            this.DataSourceUrl = null;
            this.DataSourceCreated = DateTime.MinValue;
            this.DataSourceScale = 0;
            this.DataSourceMethod = 0;
            this.Description = "";
            this.Metadata = "";
            this.Geometry = null;
        }

        /// <inheritdoc/>
        public IGeometry Geometry { get; set; }

        /// <inheritdoc/>
        public abstract AcgObjectType ObjectType { get; }

        /// <summary>
        /// Gets or sets unique object identifier.
        /// </summary>
        public Guid GUID { get; set; }

        /// <summary>
        /// Gets or sets foreign key from external data source.
        /// </summary>
        public Int32 ForeignKey { get; set; }

        /// <summary>
        /// Gets or sets object status.
        /// </summary>
        public Int16 Status { get; set; }

        /// <summary>
        /// Gets or sets name of the data source authority (organization).
        /// </summary>
        public string DataSourceAuthority { get; set; }

        /// <summary>
        /// Gets or sets name of data source author.
        /// </summary>
        public string DataSourceAuthor { get; set; }

        /// <summary>
        /// Gets or sets URL of the data source.
        /// </summary>
        public Uri DataSourceUrl { get; set; }

        /// <summary>
        /// Gets or sets date when data source was created.
        /// </summary>
        public DateTime DataSourceCreated { get; set; }

        /// <summary>
        /// Gets or sets scale of the original data source.
        /// </summary>
        public Int32 DataSourceScale { get; set; }

        /// <summary>
        /// Gets or sets method of acquisition from the original data source.
        /// </summary>
        public Int32 DataSourceMethod { get; set; }

        /// <summary>
        /// Gets or sets arbitrary object description (note).
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets arbitrary object metadata.
        /// </summary>
        public string Metadata { get; set; }

        ///// <summary>
        ///// Godina izrade prostornih podataka.
        ///// </summary>
        //public Int16 DataSourceYearCreated { get; set; }

        ///// <summary>
        ///// Mjesec izrade prostornih podataka.
        ///// </summary>
        //public Int16 DataSourceMonthCreated { get; set; }
    }
}
