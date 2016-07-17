using System;
using System.Collections.Generic;
using System.Text;

using UnityEngine;

namespace ACG.Plugins.Unity
{
    /// <summary>
    /// Unity behaviour script for setting up the spectator controller.
    /// </summary>
    /// <remarks>
    /// Attach this script to camera object.
    /// </remarks>
    public class AcgSpectatorBehaviourScript : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float forward = Input.GetAxis("Vertical");
            float sideways = Input.GetAxis("Horizontal");

            if (Input.GetKey("space"))
            {
                transform.localPosition += new Vector3(0, 0.5f, 0);
            }

            transform.localPosition += new Vector3(sideways / 2, 0, forward / 2);

            if (Input.GetKey("right alt") | Input.GetKey("left alt"))
            {
                transform.localPosition += new Vector3(0, -0.5f, 0);
            }

            if (Input.GetKey("q"))
            {
                transform.localEulerAngles += new Vector3(0, -0.5f, 0);
            }

            if (Input.GetKey("e"))
            {
                transform.localEulerAngles += new Vector3(0, 0.5f, 0);
            }

            if (Input.GetKey("c"))
            {
                transform.localEulerAngles += new Vector3(0.5f, 0, 0);
            }

            if (Input.GetKey("z"))
            {
                transform.localEulerAngles += new Vector3(-0.5f, 0, 0);
            }
        }
    }
}
