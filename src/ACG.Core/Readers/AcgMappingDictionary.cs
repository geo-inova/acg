using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Represents a dictionary of field mapping rules.
    /// </summary>
    /// <remarks>
    /// Dictionary key represents the name of <see cref="IAcgObject"/> object.
    /// </remarks>
    public class AcgMappingDictionary : Dictionary<string, List<AcgMapping>>
    {
        /// <summary>
        /// Raads file mapping rules from specified file.
        /// </summary>
        /// <param name="filePath">File path to field mappings definition file.</param>
        public void Read(string filePath)
        {
            /// TODO
        }
    }
}
