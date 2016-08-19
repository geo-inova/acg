using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

using GeoAPI.Geometries;
using NetTopologySuite.Geometries;

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
#if UNITY_EDITOR

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
#else
            //TODO: Create and assign GameObject tag in-game.
#endif
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

            string path = "";

#if UNITY_EDITOR
            path = EditorUtility.OpenFilePanel("Select Autodesk DXF file containing buildings", "", "dxf");
#else
            //TODO: in-game open file panel
#endif

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

            string path = "";

#if UNITY_EDITOR
            path = EditorUtility.OpenFilePanel("Select ESRI Shape file containing buildings", "", "shp");
#else
            //TODO: in-game open file panel
#endif

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

        /// <summary>
        /// Creates or rebuilds planar terrain.
        /// </summary>
        public static void CreatePlannarTerrain()
        {
            float xSize = 5000f;
            float zSize = 5000f;
            float ySize = 1f;

            Vector3 pos = GetCentroid();
            pos.x = pos.x - xSize / 2;
            pos.z = pos.z - zSize / 2;

            GameObject go = GameObject.Find("Terrain");

            if (go != null)
            {
                go.transform.position = pos;
            }
            else
            {
                go = new GameObject("Terrain");
                TerrainData tData = new TerrainData();

                tData.size = new Vector3(xSize, ySize, zSize);

                //int mh = tData.heightmapHeight;
                //int mw = tData.heightmapWidth;

                TerrainCollider tCol = go.AddComponent<TerrainCollider>();
                Terrain tObj = go.AddComponent<Terrain>();

                tCol.terrainData = tData;
                tObj.terrainData = tData;

                go.transform.position = pos;
            }
        }


        static IPoint GetCentroid(List<IAcgObject> objects)
        {
            if (objects.Count > 0)
            {
                IGeometry[] gArray = new Geometry[objects.Count];
                for (int i = 0; i < objects.Count; i++)
                {
                    IAcgObject obj = objects[i];
                    gArray[i] = obj.Geometry;
                }

                GeometryCollection gCol = new GeometryCollection(gArray);
                return gCol.Centroid;
            }
            else
            {
                return new Point(0, 0, 0);
            }
        }

        public static Vector3 GetCentroid()
        {
            UnityEngine.Object[] objectArray = GameObject.FindObjectsOfType(typeof(GameObject));

            List<IAcgObject> col = new List<IAcgObject>();

            foreach (UnityEngine.Object obj in objectArray)
            {
                GameObject go = (GameObject)obj;
                IAcgObjectComponent comp = go.GetComponent<IAcgObjectComponent>();

                if (comp != null)
                    if (comp.ObjectData != null)
                    {
                        col.Add(comp.ObjectData);
                    }
            }

            IPoint cent = GetCentroid(col);
            float[] tfm = Transform(cent.X, cent.Y);
            return new Vector3(tfm[0], 0, tfm[1]);
        }


        public static float[] Transform(Double x, Double y)
        {
            float x1 = (float)(AcgManager.ScaleFactorMinuendX - Math.Round(x, AcgManager.ScaleFactorSignificantDigits) * AcgManager.ScaleFactor);
            float y1 = (float)(AcgManager.ScaleFactorMinuendY - Math.Round(y, AcgManager.ScaleFactorSignificantDigits) * AcgManager.ScaleFactor);
            return new float[] { x1, y1 };
        }

        public static void CreateCamera()
        {
            GameObject go = GameObject.Find("Camera");

            if (go != null)
            {
                go.transform.position = GetCentroid();
            }
            else
            {
                go = new GameObject("Camera");
                Camera obj = go.AddComponent<Camera>();
                obj.nearClipPlane = 2f;

                Vector3 vec = GetCentroid();
                vec.y = 50f;
                go.transform.position = vec;

                go.AddComponent<AcgSpectatorBehaviourScript>();
            }
        }

        ///// <summary>
        ///// Displays open file dialog using specified parameters.
        ///// </summary>
        ///// <param name="title">Dialog title.</param>
        ///// <param name="path">Dialog initial path.</param>
        ///// <param name="extension">Dialog default extension.</param>
        ///// <returns>Selected file path or empty string if no file selected.</returns>
        //public static string ShowOpenFileDialog(string title, string path, string extension)
        //{
        //    OpenFileDialog dlg = new OpenFileDialog();
        //    dlg.Title = title;
        //    dlg.DefaultExt = extension;
        //    dlg.InitialDirectory = path;

        //    if (dlg.ShowDialog() == DialogResult.OK)
        //    {
        //        return dlg.FileName;
        //    }
        //    else
        //    {
        //        return string.Empty;
        //    }
        //}
    }
}
