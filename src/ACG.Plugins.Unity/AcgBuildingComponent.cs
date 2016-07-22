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

        //public Mesh BaseMesh { get; set; }

        /// <inheritdoc/>
        public void Draw()
        {
            AcgBuilding obj = (AcgBuilding)this.ObjectData;

            Mesh mesh = null;
            Mesh baseMesh = GetBaseMesh();
            if (baseMesh != null)
            {
                //this.BaseMesh = mesh;

                if (obj.Height != 0)
                {
                    mesh = GetExtrudedMesh(baseMesh, (float)obj.Height, false);
                }
                else
                {
                    mesh = baseMesh;
                }

                // Set up game object with mesh
                MeshFilter filter = this.gameObject.GetComponent<MeshFilter>();
                if (filter != null)
                {
                    filter.mesh = mesh;
                }
                else
                {
                    this.gameObject.AddComponent(typeof(MeshRenderer));
                    filter = this.gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
                    filter.mesh = mesh;
                }
            }

            // Apply tag to the game object
            if (string.IsNullOrEmpty(this.gameObject.tag))
            {
                AcgManager.AddTag("Building");
                this.gameObject.tag = "Building";
            }
        }

        /// <summary>
        /// Returns base mesh from building's polygon geometry.
        /// </summary>
        /// <returns></returns>
        public Mesh GetBaseMesh()
        {
            if (this.ObjectData != null)
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
                Mesh mesh = new Mesh();
                mesh.vertices = vertices;
                mesh.triangles = indices;

                mesh.uv = new Vector2[mesh.vertices.Length];
                for (int i = 0; i < mesh.vertices.Length; i++)
                {
                    mesh.uv[i] = new Vector2(1f, 0);
                }

                mesh.RecalculateNormals();
                mesh.RecalculateBounds();
                mesh.Optimize();

                return mesh;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Returns extruded mesh given the specified base mesh.
        /// </summary>
        /// <param name="baseMesh">Base mesh.</param>
        /// <param name="height">Mesh extrusion height.</param>
        /// <param name="invertFaces">Invert mesh faces.</param>
        /// <returns></returns>
        public Mesh GetExtrudedMesh(Mesh baseMesh, float height, bool invertFaces)
        {
            Mesh mesh = new Mesh();

            Matrix4x4[] extrusionPath = new Matrix4x4[2];
            extrusionPath[0] = this.gameObject.transform.worldToLocalMatrix * Matrix4x4.TRS(this.gameObject.transform.position, Quaternion.identity, Vector3.one);
            extrusionPath[1] = this.gameObject.transform.worldToLocalMatrix * Matrix4x4.TRS(this.gameObject.transform.position + new Vector3(0, height, 0), Quaternion.identity, Vector3.one);
            MeshExtrusion.ExtrudeMesh(baseMesh, mesh, extrusionPath, invertFaces);

            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            mesh.Optimize();

            return mesh;
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
