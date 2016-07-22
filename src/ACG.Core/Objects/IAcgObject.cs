using System;
using System.Collections.Generic;
using System.Text;

using GeoAPI.Geometries;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Interface pertaining to AreaCAD-GIS objects.
    /// </summary>
    public interface IAcgObject
    {
        /// <summary>
        /// Gets or sets object geometry.
        /// </summary>
        IGeometry Geometry { get; set; }

        /// <summary>
        /// Returns AreaCAD-GIS object type.
        /// </summary>
        AcgObjectType ObjectType { get; }

        /// <summary>
        /// Gets or sets arbitrary object metadata.
        /// </summary>
        string Metadata { get; set; }
    }
}
