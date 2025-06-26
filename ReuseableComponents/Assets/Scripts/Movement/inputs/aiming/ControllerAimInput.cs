using System;
using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class ControllerAimInput : MonoBehaviour, IAimInput
    {
        private Transform controllerOrigin;
        // [SerializeField] private float aimDistance = 1000f;

        private void Awake()
        {
            if (controllerOrigin == null)
            {
                Camera mainCam = Camera.main;
                if (mainCam != null)
                {
                    controllerOrigin = mainCam.transform;
                }
            }
        }

        public Ray GetAimDirection()
        {
            float horizontal = Input.GetAxis("AimHorizontal");
            float vertical = Input.GetAxis("AimVertical");

            // Deadzone check
            Vector2 input = new Vector2(horizontal, vertical);
            if (input.sqrMagnitude < 0.01f)
            {
                // Default to center of screen
                return Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));
            }

            // Adjust these values to tune cursor position on screen
            float aimSensitivity = 300f;

            // Calculate fake screen position based on stick input
            Vector2 stickOffset = input.normalized * aimSensitivity;

            Vector3 screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
            Vector3 virtualCursorPos = screenCenter + new Vector3(stickOffset.x, stickOffset.y, 0);

            return Camera.main.ScreenPointToRay(virtualCursorPos);
        }
    }
}