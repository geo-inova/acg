using System;
using System.Collections.Generic;
using System.Text;

using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Interface pertaining to <see cref="IAcgObject"/> data readers.
    /// </summary>
    public interface IAcgReader
    {
        /// <summary>
        /// Reads the data given physical path.
        /// </summary>
        /// <param name="filePath">Physical path of source file or folder.</param>
        /// <returns>List of <see cref="IAcgObject"/> objects.</returns>
        List<IAcgObject> Read(string filePath);

        /// <summary>
        /// Gets or sets <see cref="AcgObjectType"/> to read.
        /// </summary>
        AcgObjectType ObjectType { get; set; }

        /// <summary>
        /// Gets or sets field mapping rules.
        /// </summary>
        AcgMappingDictionary Mappings { get; set; }
    }
}
