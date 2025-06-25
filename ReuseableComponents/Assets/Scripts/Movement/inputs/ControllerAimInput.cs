using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class ControllerAimInput : MonoBehaviour, IAimInput
    {
        [SerializeField] private Transform controllerOrigin; // where the ray starts (e.g., camera or player head)
        // [SerializeField] private float aimDistance = 1000f;

        public Ray GetAimDirection()
        {
            float horizontal = Input.GetAxis("AimHorizontal");
            float vertical = Input.GetAxis("AimVertical");

            Vector3 aimDirection = new Vector3(horizontal, 0, vertical).normalized;

            return new Ray(controllerOrigin.position, aimDirection);
        }
    }
}