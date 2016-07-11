using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents AreaCAD-GIS object type(s).
    /// </summary>
    [Flags]
    public enum AcgObjectType
    {
        /// <summary>
        /// Any object type.
        /// </summary>
        Any = 0,

        /// <summary>
        /// Permanent residental, commercial or utility structure.
        /// </summary>
        Building = 1
    }
}
