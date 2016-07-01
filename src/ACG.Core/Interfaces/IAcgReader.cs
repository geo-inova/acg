using System;
using System.Collections.Generic;
using System.Text;

namespace ACG.Core.Interfaces
{
    /// <summary>
    /// Interface pertaining to data readers.
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
