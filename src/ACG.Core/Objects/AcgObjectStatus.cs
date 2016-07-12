using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents AreaCAD-GIS object status.
    /// </summary>
    public enum AcgObjectStatus
    {
        /// <summary>
        /// Object status unknown.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Planned object.
        /// </summary>
        Planned = 1,

        /// <summary>
        /// Object under construction.
        /// </summary>
        Construction = 2,

        /// <summary>
        /// Existing object.
        /// </summary>
        Existing = 3
    }
}
