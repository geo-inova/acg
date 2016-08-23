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
    [Serializable]
    public class AcgBuildingComponent : MonoBehaviour, IAcgObjectComponent
    {
        /// <inheritdoc/>
        [SerializeField]
        public IAcgObject ObjectData { get; set; }

        /// <inheritdoc/>
        public void Draw()
        {
            AcgBuilding obj = (AcgBuilding)this.ObjectData;

            if (obj != null)
            {
                Mesh mesh = null;

                Polygon pol = (Polygon)ObjectData.Geometry;

                Mesh baseMesh = AcgManager.GetMeshFromPolygon(pol);
                if (baseMesh != null)
                {
                    if (obj.Height != 0)
                    {
                        mesh = AcgManager.GetExtrudedMesh(this.gameObject, baseMesh, (float)obj.Height, false);
                    }
                    else
                    {
                        mesh = baseMesh;
                    }

                    // Create mesh filter
                    MeshFilter filter = this.gameObject.GetComponent<MeshFilter>();
                    if (filter != null)
                    {
                        filter.mesh = mesh;
                    }
                    else
                    {
                        this.gameObject.AddComponent(typeof(MeshRenderer));
                        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
                        renderer.material = Resources.Load<Material>("Materials/Building");

                        filter = this.gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
                        filter.mesh = mesh;
                    }

                    // Create mesh collider
                    MeshCollider meshc = this.gameObject.GetComponent<MeshCollider>();
                    if (meshc != null)
                    {
                        meshc.sharedMesh = null;
                        meshc.sharedMesh = mesh;
                    }
                    else
                    {
                        Component compc = this.gameObject.AddComponent(typeof(MeshCollider));
                        meshc = (MeshCollider)compc;
                        meshc.sharedMesh = null;
                        meshc.sharedMesh = mesh;
                    }
                }
            }
        }
    }
}
