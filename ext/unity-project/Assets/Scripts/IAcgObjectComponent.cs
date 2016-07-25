using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ACG.Core.Objects;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Interface pertaining to <see cref="IAcgObject"/> based components.
    /// </summary>
    public interface IAcgObjectComponent
    {
        /// <summary>
        /// Instantiates this <see cref="IAcgObject"/> within Unity scene.
        /// </summary>
        void Draw();

        /// <summary>
        /// Gets or sets component's <see cref="IAcgObject"/> data.
        /// </summary>
        IAcgObject ObjectData { get; set; }
    }
}
