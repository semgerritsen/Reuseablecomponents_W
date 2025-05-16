using Interfaces;
using UnityEngine;

namespace Movement
{
    // [RequireComponent(typeof(IMovement))]
    // [RequireComponent(typeof(IMovementInput))]
    public class PlayerMove : MonoBehaviour
    {
        private IMovement movement;
        private IMovementInput movementInput;
        private void Awake()
        {
            movement = GetComponent<IMovement>();
            movementInput = GetComponent<IMovementInput>();
        }
        private void Update()
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(Vector3.up * mouseX * 3f); // 3f is sensitivity, adjust as needed
            Vector3 dir = transform.TransformDirection(movementInput.GetMovementDirection());
            movement.Move(dir);
        }
    }
}