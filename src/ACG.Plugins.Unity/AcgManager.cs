using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEditor;
using UnityEngine;

using ACG.Core;
using ACG.Core.Objects;
using ACG.Core.Readers;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Represents AreaCAD-GIS manager for Unity.
    /// </summary>
    class AcgManager
    {
        /// <summary>
        /// Returns global length conversion scaling factor.
        /// </summary>
        public static double ScaleFactor = 1;

        /// <summary>
        /// Returns global X-axis scaling minuend.
        /// </summary>
        public static double ScaleFactorMinuendX = 6430000;

        /// <summary>
        /// Returns global Y-axis scaling minuend.
        /// </summary>
        public static double ScaleFactorMinuendY = 4950000;

        /// <summary>
        /// Returns global number of significant digits for length conversion scaling factor.
        /// </summary>
        public static int ScaleFactorSignificantDigits = 2;


        /// <summary>
        /// Imports buildings from DXF file.
        /// </summary>
        public static void ImportBuildingsDxf()
        {
            //Intialize new DXF reader instance
            AcgDxfReader reader = new AcgDxfReader();

            //Return only building objects
            reader.ObjectType = AcgObjectType.Building;

            string path = EditorUtility.OpenFilePanel("Select Autodesk DXF file containing buildings", "", "dxf");

            if (path.Length != 0)
            {
                //Read ACG objects from specified file
                ImportBuildings(reader.Read(path));
            }
        }

        /// <summary>
        /// Imports buildings from SHP file.
        /// </summary>
        public static void ImportBuildingsShp()
        {
            //Intialize new SHP reader instance
            AcgShpReader reader = new AcgShpReader();

            //Return only building objects
            reader.ObjectType = AcgObjectType.Building;

            string path = EditorUtility.OpenFilePanel("Select ESRI Shape file containing buildings", "", "shp");

            if (path.Length != 0)
            {
                //Read ACG objects from specified file
                ImportBuildings(reader.Read(path));
            }
        }


        static void ImportBuildings(List<IAcgObject> objs)
        {
            foreach (IAcgObject obj in objs)
            {
                GameObject go = new GameObject("Building");
                AcgBuildingComponent goc = go.AddComponent<AcgBuildingComponent>();
                goc.ObjectData = (AcgBuilding)obj;
                goc.Draw();
            }
        }
    }
}
