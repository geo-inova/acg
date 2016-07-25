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
        [SerializeField]
        // Maximumu speed of camera
        private float cameraSpeed = 25.0f;

        [SerializeField]
        // Camera sensitivity keep it between 0 ... 1
        private float cameraSensitivity = 0.25f;

        [SerializeField]
        // Variable to store actual speed of camera translation, ranges between 0 ... 1
        private float cameraActualSpeed = 0.0f;

        [SerializeField]
        // Acceleration of camera translation
        private float cameraAccelaration = 0.5f;

        [SerializeField]
        // Inverts camera Y direction for user choice
        private bool invertCameraControl = false;

        [SerializeField]
        // Smooth camera movement
        private bool cameraSmoothing = true;

        [SerializeField]
        // Last mouse position represented as vector
        private Vector3 lastMousePosition = new Vector3(128, 128, 128);

        // Captures last detected camera direction
        private Vector3 lastCameraDirection = new Vector3();

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            #region ~ rotate camera ~

            // Finds actual last mouse position and rotation and store it in a vector lastMousePosition
            lastMousePosition = Input.mousePosition - lastMousePosition;

            // For invert camera, works on Y axis only
            if (!invertCameraControl)
            {
                lastMousePosition.y = -lastMousePosition.y;
            }

            lastMousePosition *= cameraSensitivity;
            lastMousePosition = new Vector3(transform.eulerAngles.x + lastMousePosition.y,
                                            transform.eulerAngles.y + lastMousePosition.x,
                                            0);
            transform.eulerAngles = lastMousePosition;
            lastMousePosition = Input.mousePosition;
            #endregion

            #region ~ Move camera ~

            // Initialize camera direction vector to {0,0,0}
            Vector3 cameraDirection = new Vector3();

            // Move camera in horizontal plane by pressing WASD or Arrows, cameraDirection vector
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                cameraDirection.z += 1.0f;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                cameraDirection.z -= 1.0f;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                cameraDirection.x += 1.0f;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                cameraDirection.x -= 1.0f;
            }

            // Lift camera by pressing SPACE
            if (Input.GetKey(KeyCode.Space))
            {
                cameraDirection.y += 1.0f;
            }

            // Applay soothing of camera translation
            if (cameraDirection != Vector3.zero)
            {
                if (cameraActualSpeed < 1)
                {
                    cameraActualSpeed += cameraAccelaration * Time.deltaTime;
                }
                else
                {
                    cameraActualSpeed = 1.0f;
                }

                lastCameraDirection = cameraDirection;
            }
            else
            {
                if (cameraActualSpeed > 1)
                {
                    cameraActualSpeed -= cameraAccelaration * Time.deltaTime;
                }
                else
                {
                    cameraActualSpeed = 0.0f;
                }
            }
            #endregion

            // Keep camera direction vector between 0 ... 1
            cameraDirection.Normalize();

            // Test for camera smoothing option
            if (cameraSmoothing)
            {
                // Actual translation of camera with respect to direction, speed and time
                transform.Translate(lastCameraDirection * cameraSpeed * cameraActualSpeed * Time.deltaTime);
            }
            else
            {
                // Camera translation if smoothing option is turned off
                transform.Translate(lastCameraDirection * cameraSpeed * Time.deltaTime);
            }
        }
    }
}
