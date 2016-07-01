using System;
using System.Collections.Generic;
using System.Text;

namespace ACG.Core.Interfaces
{
    interface IAcgReader
    {

        List<IAcgObject> Read(string filePath);

    }
}
