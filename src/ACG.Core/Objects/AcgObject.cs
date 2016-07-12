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
            this.Status = AcgObjectStatus.Unknown;
            this.DataSourceAuthority = "";
            this.DataSourceAuthor = "";
            this.DataSourceUrl = null;
            this.DataSourceYear = 0;
            this.Description = "";
            this.Metadata = "";
            this.Geometry = null;
        }

        /// <summary>
        /// Gets or sets unique object identifier.
        /// </summary>
        public Guid GUID { get; set; }

        /// <summary>
        /// Gets or sets object status.
        /// </summary>
        public AcgObjectStatus Status { get; set; }

        /// <summary>
        /// Gets or sets name of the data source authority.
        /// </summary>
        public string DataSourceAuthority { get; set; }

        /// <summary>
        /// Gets or sets the name of data source author.
        /// </summary>
        public string DataSourceAuthor { get; set; }

        /// <summary>
        /// Gets or sets URL of the data source.
        /// </summary>
        public Uri DataSourceUrl { get; set; }

        /// <summary>
        /// Gets or sets the year when data source was created.
        /// </summary>
        public int DataSourceYear { get; set; }

        /// <summary>
        /// Gets or sets arbitrary object description (note).
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets aritrary object metadata.
        /// </summary>
        public string Metadata { get; set; }

        /// <summary>
        /// Gets or sets object geometry.
        /// </summary>
        public IGeometry Geometry { get; set; }
    }
}
