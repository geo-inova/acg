using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACG.Core.Objects
{
    /// <summary>
    /// Represents a cadastral parcel, basic building block of national land registry.
    /// </summary>
    /// <remarks>
    /// Geometry is always polygonal.
    /// </remarks>
    public class AcgParcel : AcgObject
    {
        /// <inheritdoc/>
        public AcgParcel()
        {
           
        }

        /// <inheritdoc/>
        public override AcgObjectType ObjectType
        {
            get 
            { 
                return AcgObjectType.Parcel; 
            }
        }
    }
}
