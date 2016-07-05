using System;
using System.Collections.Generic;
using System.Text;

using ACG.Core.Objects;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Interface pertaining to <seealso cref="IAcgObject"/> data readers.
    /// </summary>
    public interface IAcgReader
    {
        /// <summary>
        /// Reads the data given physical path.
        /// </summary>
        /// <param name="filePath">Physical path of source file or folder.</param>
        /// <returns>List of <seealso cref="IAcgObject"/> objects.</returns>
        List<IAcgObject> Read(string filePath);

    }
}
