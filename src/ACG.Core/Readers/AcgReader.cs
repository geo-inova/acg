using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ACG.Core;
using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Represents base class for any AreaCAD-GIS data reader.
    /// </summary>
    public abstract class AcgReader : IAcgReader
    {
        /// <inheritdoc/>
        public AcgReader()
        {
            this.ObjectType = AcgObjectType.Any;
        }

        /// <inheritdoc/>
        public abstract List<IAcgObject> Read(string filePath);

        /// <inheritdoc/>
        public AcgObjectType ObjectType { get; set; }
    }
}
