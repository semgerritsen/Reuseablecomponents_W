using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class ControllerWeaponInput : MonoBehaviour, IWeaponInput
    {
        // This script handles weapon input for a controller, checking if the right trigger is pressed to determine if the player is firing.
        public bool IsFiring()
        {
            // Check if the right trigger is pressed
            return Input.GetAxis("RightTrigger") > 0.1f;
        }
    }
}