using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class ControllerInput : MonoBehaviour, IMovementInput
    {
        public Vector3 GetMovementDirection()
        {
            // Get input from the controller's left joystick
            float horizontal = Input.GetAxis("Horizontal");
            // Get input from the controller's left joystick
            float vertical = Input.GetAxis("Vertical");
            
            // Create a direction vector based on the input
            Vector3 direction = new Vector3(horizontal, 0, vertical);
            // return the normalized direction vector
            return direction.normalized;
        }
    }
}