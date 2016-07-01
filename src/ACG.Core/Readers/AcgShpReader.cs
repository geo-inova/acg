using System;
using System.Collections.Generic;
using System.Text;

using ACG.Core.Interfaces;
using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Data reader for ESRI SHP files.
    /// </summary>
    public class AcgShpReader : IAcgReader
    {
        /// <inheritdoc/>
        public List<IAcgObject> Read(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
