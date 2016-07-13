using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.Readers
{
    /// <summary>
    /// Represents a single field mapping rule.
    /// </summary>
    public class AcgMapping
    {
         /// <inheritdoc/>
        public AcgMapping()
        {
            this.Source = "";
            this.Target = "";
        }

        /// <summary>
        /// Gets or sets source field name.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Gets or sets target field name.
        /// </summary>
        public string Target { get; set; }
    }
}
