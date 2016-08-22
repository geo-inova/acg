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
    /// Represents <see cref="AcgParcel"/> Unity component.
    /// </summary>
    [Serializable]
    public class AcgParcelComponent : MonoBehaviour, IAcgObjectComponent
    {
        /// <inheritdoc/>
        [SerializeField]
        public IAcgObject ObjectData { get; set; }

        /// <inheritdoc/>
        public void Draw()
        {
            AcgParcel obj = (AcgParcel)this.ObjectData;

            if (this.ObjectData != null)
            {
                Mesh mesh = null;

                Polygon pol = (Polygon)ObjectData.Geometry;

                Mesh baseMesh = AcgManager.GetMeshFromPolygon(pol);
                if (baseMesh != null)
                {
                    //if (obj.Height != 0)
                    //{
                        mesh = AcgManager.GetExtrudedMesh(this.gameObject, baseMesh, 0.5f, false);
                    //}
                    //else
                    //{
                    //    mesh = baseMesh;
                    //}

                    // Set up game object with mesh
                    MeshFilter filter = this.gameObject.GetComponent<MeshFilter>();
                    if (filter != null)
                    {
                        filter.mesh = mesh;
                    }
                    else
                    {
                        this.gameObject.AddComponent(typeof(MeshRenderer));
                        MeshRenderer renderer = this.gameObject.GetComponent<MeshRenderer>();
                        renderer.material = Resources.Load<Material>("Materials/Parcel");

                        filter = this.gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
                        filter.mesh = mesh;
                    }
                }
            }

            // Apply tag to the game object
            if (this.gameObject.tag == "Untagged")
            {
                AcgManager.AddTag("AcgParcel");
                this.gameObject.tag = "AcgParcel";
            }
        }

    }
}
