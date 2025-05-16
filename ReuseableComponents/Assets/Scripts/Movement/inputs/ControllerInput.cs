using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class ControllerInput : MonoBehaviour, IMovementInput
    {
        public Vector3 GetMovementDirection()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            
            Vector3 direction = new Vector3(horizontal, 0, vertical);
            return direction.normalized;
        }
    }
}