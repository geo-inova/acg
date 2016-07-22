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
    public class AcgManager
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
        /// Enables or disables displaying Unity objects by specified tag.
        /// </summary>
        /// <param name="name">Tag name.</param>
        /// <param name="enabled">Object visibility.</param>
        public static void EnableByTag(string name, bool enabled)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag(name);

            foreach (GameObject go in gameObjectArray)
            {
                go.GetComponent<Renderer>().enabled = enabled;
            }
        }

        /// <summary>
        /// Removes Unity objects by specified tag.
        /// </summary>
        /// <param name="name">Tag name.</param>
        public static void RemoveByTag(string name)
        {
            GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag(name);

            foreach (GameObject go in gameObjectArray)
            {
                UnityEngine.Object.DestroyImmediate(go);
            }
        }

        /// <summary>
        /// Adds specified Unity tag if it does not already exist.
        /// </summary>
        /// <param name="name">Tag name.</param>
        public static void AddTag(string name)
        {
            // Open tag manager
            SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
            SerializedProperty tagsProp = tagManager.FindProperty("tags");

            // First check if it is not already present
            bool found = false;
            for (int i = 0; i < tagsProp.arraySize; i++)
            {
                SerializedProperty t = tagsProp.GetArrayElementAtIndex(i);
                if (t.stringValue.Equals(name)) { found = true; break; }
            }

            // if not found, add it
            if (!found)
            {
                tagsProp.InsertArrayElementAtIndex(0);
                SerializedProperty n = tagsProp.GetArrayElementAtIndex(0);
                n.stringValue = name;
            }

            SerializedProperty sp = tagManager.FindProperty(name);
            if (sp != null) sp.stringValue = name;

            // and to save the changes
            tagManager.ApplyModifiedProperties();
        }

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
                //go.tag = "Building";
                AcgBuildingComponent goc = go.AddComponent<AcgBuildingComponent>();
                goc.ObjectData = obj;
                goc.Draw();
            }
        }
    }
}
