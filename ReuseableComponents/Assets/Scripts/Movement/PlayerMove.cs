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

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Vector3 dir = movementInput.GetMovementDirection();
            movement.Move(dir);
        }
    }
}