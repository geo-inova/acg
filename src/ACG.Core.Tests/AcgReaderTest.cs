using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ACG.Core;
using ACG.Core.Readers;
using ACG.Core.Objects;

namespace ACG.Core.Tests
{
    [TestClass]
    public class AcgReaderTest
    {
        [TestMethod]
        public void AcgShpReaderTest()
        {
            //Intialize new SHP reader instance
            AcgShpReader reader = new AcgShpReader();

            //Return only building objects
            reader.ObjectType = AcgObjectType.Building;

            //Get path to specific SHP file
            string fileName = Path.Combine(GetDatPath(), @"shp\banjaluka_jug_6.shp");

            //Read ACG objects from SHP file
            List<IAcgObject> objs = reader.Read(fileName);
             
        }

        /// <summary>
        /// Returns absolute path to local ..\dat folder.
        /// </summary>
        /// <returns></returns>
        string GetDatPath()
        {
            string asmPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string relPath = Path.Combine(asmPath, @"..\..\dat");
            string absPath = Path.GetFullPath((new Uri(relPath)).LocalPath);
            
            return absPath;
        }
    }
}
