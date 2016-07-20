using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;
using UnityEditor;

using ACG.Core.Objects;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Represents <see cref="AcgBuilding"/> Unity component editor.
    /// </summary>
    [CustomEditor(typeof(AcgBuildingComponent))]
    public class AcgBuildingComponentEditor : Editor
    {

        AcgBuildingComponent _target;

        void OnEnable()
        {
            _target = (AcgBuildingComponent)target;
        }

        /// <summary>
        /// Implement this function to make a custom inspector.
        /// </summary>
        public override void OnInspectorGUI()
        {
            if (_target.ObjectData != null)
            {
                AcgBuilding obj = (AcgBuilding)_target.ObjectData;

                GUILayout.BeginVertical();

                GUILayout.Label("Building", EditorStyles.boldLabel);
                obj.HeightFixed = EditorGUILayout.DoubleField("Height", obj.HeightFixed);

                if (obj.Height == 0)
                { EditorGUILayout.HelpBox("Building height not set.", MessageType.Warning); }

                GUILayout.EndVertical();

                //If we changed the GUI aply the new values to the script
                if (GUI.changed)
                {
                    EditorUtility.SetDirty(_target);
                }
            }
        }
    }
}