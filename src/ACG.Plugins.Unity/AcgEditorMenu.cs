﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using ACG.Core;
using ACG.Core.Objects;
using ACG.Core.Readers;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Represents Unity menu definition(s) for AreaCAD-GIS.
    /// </summary>
    public class AcgEditorMenu
    {
        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Import DXF...")]
        private static void ImportBuildings()
        {
            AcgManager.ImportBuildingsDxf();
        }

        [UnityEditor.MenuItem("AreaCAD-GIS/Buildings/Import SHP...")]
        private static void ImportBuildingsShp()
        {
            AcgManager.ImportBuildingsShp();
        }
    }
}