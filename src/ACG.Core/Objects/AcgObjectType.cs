using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents AreaCAD-GIS object type.
    /// </summary>
    public enum AcgObjectType
    {
        /// <summary>
        /// Object(s) of any type.
        /// </summary>
        Any = 0,

        /// <summary>
        /// Permanent residental, commercial or utility structure.
        /// </summary>
        Building = 1,

        /// <summary>
        /// Cadastral parcel, a basic building block of national land registry.
        /// </summary>
        Parcel = 2
    }
}
