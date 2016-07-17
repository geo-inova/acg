using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Unity behaviour script for setting up the environment and GUI.
    /// </summary>
    /// <remarks>
    /// Remove all GameObjects before running, then create empty GameObject and attach this script to it.
    /// </remarks>
    public class AcgEnvironmentBehaviourScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            GameObject light = new GameObject("Sun");
            Light lightComp = light.AddComponent<Light>();

            light.transform.position = new Vector3(25f, 10f, 25f);//sve vrijednosti su za sad samo probne
            lightComp.range = 50;


            GameObject Terrain1 = new GameObject("Terrain");
            TerrainData tD = new TerrainData();

            tD.size = new Vector3(50f, 1f, 50f);


            int mh = tD.heightmapHeight;
            int mw = tD.heightmapWidth;

            TerrainCollider tC = Terrain1.AddComponent<TerrainCollider>();
            Terrain Terrain2 = Terrain1.AddComponent<Terrain>();

            tC.terrainData = tD;
            Terrain2.terrainData = tD;
            Terrain1.transform.position = new Vector3(0, 0, 0);

            GameObject camera = new GameObject("Camera");
            camera.AddComponent<Camera>();
            camera.transform.position = new Vector3(25f, 2f, 4f);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
