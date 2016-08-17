#if UNITY_EDITOR
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
    [CanEditMultipleObjects]
    [Serializable]
    public class AcgBuildingComponentEditor : Editor
    {
        [SerializeField]
        UnityEngine.Object[] _targets;

        private static bool categoryVerticalDimensions = true;

        void OnEnable()
        {
            _targets = (UnityEngine.Object[])targets;
        }

        /// <summary>
        /// Implement this function to make a custom inspector.
        /// </summary>
        public override void OnInspectorGUI()
        {
            Double heightFixed = 0;
            Double heightFixedNew = 0;

            AcgBuildingComponent cobj = (AcgBuildingComponent)_targets[0];
            if (cobj.ObjectData != null)
            {
                AcgBuilding obj = (AcgBuilding)cobj.ObjectData;
                heightFixed = obj.HeightFixed;
            }

            //Layout
            GUILayout.BeginVertical();
            GUILayout.Label("Building", EditorStyles.boldLabel);

            categoryVerticalDimensions = EditorGUILayout.Foldout(categoryVerticalDimensions, "Vertical Dimensions");
            if (categoryVerticalDimensions)
            {
                heightFixedNew = EditorGUILayout.DoubleField("Measured Height (m)", heightFixed);

                if (heightFixedNew == 0)
                { EditorGUILayout.HelpBox("Building height not set.", MessageType.Warning); } 
            }
            GUILayout.EndVertical();

            //Assign new value(s) to properties
            heightFixed = heightFixedNew;

            //If we changed the GUI apply new values to the script
            if (GUI.changed)
            {
                for (int i = 0; i < _targets.Length; i++)
                {
                    AcgBuildingComponent tobj = (AcgBuildingComponent)_targets[i];
                    if (tobj.ObjectData != null)
                    {
                        AcgBuilding obj = (AcgBuilding)tobj.ObjectData;
                        obj.HeightFixed = heightFixed;

                        EditorUtility.SetDirty(tobj);
                        serializedObject.ApplyModifiedProperties();

                        //Redraw the GameObject
                        tobj.Draw();
                    }
                }
            }
        }
    }
}
#endif