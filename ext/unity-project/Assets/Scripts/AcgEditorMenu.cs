using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using ACG.Core;
using ACG.Core.Objects;
using ACG.Core.Readers;

namespace ACG.Plugins.Unity
{
#if UNITY_EDITOR

    /// <summary>
    /// Represents Unity menu definition(s) for AreaCAD-GIS.
    /// </summary>
    public class AcgEditorMenu
    {
        // Camera

        [UnityEditor.MenuItem("AreaCAD-GIS/Camera/Reposition", false, 1)]
        private static void CreateCamera()
        {
            AcgManager.CreateCamera();
        }

        // Terrain

        [UnityEditor.MenuItem("AreaCAD-GIS/Terrain/Build Planar", false, 2)]
        private static void CreatePlane()
        {
            AcgManager.CreatePlannarTerrain();
        }

        //Buildings

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Import DXF...", false, 3)]
        private static void ImportBuildings()
        {
            AcgManager.ImportBuildingsDxf();
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Import SHP...", false, 4)]
        private static void ImportBuildingsShp()
        {
            AcgManager.ImportBuildingsShp();
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Show", false, 50)]
        private static void ShowBuilding()
        {
            AcgManager.EnableByTag("AcgBuilding", true);
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Hide", false, 51)]
        private static void HideBuilding()
        {
            AcgManager.EnableByTag("AcgBuilding", false);
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Remove all", false, 100)]
        private static void RemoveBuilding()
        {
            AcgManager.RemoveByTag("AcgBuilding");
        }

        //Parcels

        [UnityEditor.MenuItem("AreaCAD-GIS/Parcels/Import SHP...", false, 5)]
        private static void ImportParcelsShp()
        {
            AcgManager.ImportParcelsShp();
        }
    }

#endif
}
