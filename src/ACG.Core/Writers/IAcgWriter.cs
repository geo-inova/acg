using System;
using System.Collections.Generic;
using System.Text;

using ACG.Core.Objects;

namespace ACG.Core.Writers
{
    /// <summary>
    /// Interface pertaining to <see cref="IAcgObject"/> data writers.
    /// </summary>
    public interface IAcgWriter
    {
        /// <summary>
        /// Writes specified data to a physical path.
        /// </summary>
        /// <param name="data">List of <see cref="IAcgObject"/> objects.</param>
        /// <param name="filePath">Physical path of target file or folder.</param>
        void Write(List<IAcgObject> data, string filePath);
    }
}
