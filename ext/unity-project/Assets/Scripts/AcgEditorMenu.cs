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
        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Import DXF...", false, 1)]
        private static void ImportBuildings()
        {
            AcgManager.ImportBuildingsDxf();
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Import SHP...", false, 2)]
        private static void ImportBuildingsShp()
        {
            AcgManager.ImportBuildingsShp();
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Show", false, 13)]
        private static void ShowBuilding()
        {
            AcgManager.EnableByTag("AcgBuilding", true);
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Hide", false, 13)]
        private static void HideBuilding()
        {
            AcgManager.EnableByTag("AcgBuilding", false);
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Remove all", false, 24)]
        private static void RemoveBuilding()
        {
            AcgManager.RemoveByTag("AcgBuilding");
        }
    }

#endif
}
