using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    /// <summary>
    ///  Handles keyboard input for movement.
    /// </summary>
    public class KeyboardInput : MonoBehaviour , IMovementInput
    {
        [SerializeField] private KeyCode forwardKey = KeyCode.W;
        [SerializeField] private KeyCode backwardKey = KeyCode.S;
        [SerializeField] private KeyCode leftKey = KeyCode.A;
        [SerializeField] private KeyCode rightKey = KeyCode.D;
        
        public Vector3 GetMovementDirection()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(forwardKey))
                direction += Vector3.forward;
            if (Input.GetKey(backwardKey))
                direction += Vector3.back;
            if (Input.GetKey(leftKey))
                direction += Vector3.left;
            if (Input.GetKey(rightKey))
                direction += Vector3.right;

            return direction.normalized;
        }
    }
    
}