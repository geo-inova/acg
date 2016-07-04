using System;
using System.Collections.Generic;
using System.Text;

using ACG.Core.Interfaces;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents base class for any AreaCAD-GIS object.
    /// </summary>
    public abstract class AcgObject : IAcgObject
    {
        /// <summary>
        /// Gets or sets unique object identifier.
        /// </summary>
        public Guid GUID = Guid.NewGuid();

        /// <summary>
        /// Gets or sets name of the data source authority.
        /// </summary>
        public string DataSourceAuthority = "";

        /// <summary>
        /// Gets or sets object metadata (temporary).
        /// </summary>
        public string Metadata = "";
    }
}
