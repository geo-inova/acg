using System;
using System.Collections.Generic;
using System.Text;

using GeoAPI.Geometries;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents a building.
    /// </summary>
    /// <remarks>
    /// Building base geometry is always polygonal.
    /// </remarks>
    public class AcgBuilding : AcgObject
    {
        /// <inheritdoc/>
        public AcgBuilding()
        {
            this.HeightFixed = 0;
            this.StreetName = "";
            this.StreetNumber = "";
            this.TotalGrossSurfaceFixed = 0;
        }

        /// <summary>
        /// Returns building height (m).
        /// </summary>
        public double Height
        {
            get
            {
                return this.HeightFixed;
            }
        }

        /// <summary>
        /// Gets or sets measured building height (m).
        /// </summary>
        public double HeightFixed { get; set; }

        /// <summary>
        /// Gets or sets building street name.
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets building street number.
        /// </summary>
        public string StreetNumber { get; set; }

        /// <summary>
        /// Returns building total gross surface (sqm).
        /// </summary>
        public double TotalGrossSurface
        {
            get
            {
                return this.TotalGrossSurfaceFixed;
            }
        }

        /// <summary>
        /// Gets or sets measured building total gross surface (sqm).
        /// </summary>
        public double TotalGrossSurfaceFixed { get; set; }
    }
}
