using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

using GeoAPI.Geometries;
using NetTopologySuite.Geometries;

using ACG.Core.Objects;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Represents <see cref="AcgBuilding"/> Unity component.
    /// </summary>
    public class AcgBuildingComponent : MonoBehaviour, IAcgObjectComponent
    {
        /// <inheritdoc/>
        public IAcgObject ObjectData { get; set; }

        /// <inheritdoc/>
        public void Draw()
        {
            Polygon pol = (Polygon)ObjectData.Geometry;

            int len = pol.ExteriorRing.Coordinates.Length - 1;
            Vector2[] vertices2D = new Vector2[len];

            for (int i = 0; i < len; i++)
            {
                Coordinate c = pol.ExteriorRing.Coordinates[i];
                float x = (float)(AcgManager.ScaleFactorMinuendX - Math.Round(c.X, AcgManager.ScaleFactorSignificantDigits) * AcgManager.ScaleFactor);
                float y = (float)(AcgManager.ScaleFactorMinuendY - Math.Round(c.Y, AcgManager.ScaleFactorSignificantDigits) * AcgManager.ScaleFactor);
                vertices2D[i] = new Vector2(x, y);
            }

            // Use the triangulator to get indices for creating triangles
            Triangulator tr = new Triangulator(vertices2D);
            int[] indices = tr.Triangulate();

            // Create the Vector3 vertices
            Vector3[] vertices = new Vector3[vertices2D.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i] = new Vector3(vertices2D[i].x, 0, vertices2D[i].y);
            }

            // Create the mesh
            Mesh msh = new Mesh();
            msh.vertices = vertices;
            msh.triangles = indices;
            msh.RecalculateNormals();
            msh.RecalculateBounds();
            msh.Optimize();

            // Set up game object with mesh;
            this.gameObject.AddComponent(typeof(MeshRenderer));
            MeshFilter filter = this.gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
            filter.mesh = msh;
        }

        //// Use this for initialization
        //void Start()
        //{
        
        //}

        //// Update is called once per frame
        //void Update()
        //{

        //}
    }
}
