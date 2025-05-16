using Interfaces;
using UnityEngine;

namespace Movement
{
    [RequireComponent(typeof(CharacterController))]
    public class SwiftMovement : MonoBehaviour, IMovement
    {
        [Header("Movement speeds")]
        [SerializeField] private float walkSpeed       = 5f;
        [SerializeField] private float sprintMultiplier = 1.8f;

        private CharacterController controller;
        
        private void Awake() => controller = GetComponent<CharacterController>();

        public void Move(Vector3 direction)
        {
            bool isSprinting = Input.GetKey(KeyCode.LeftShift);
            float speed;
            if (isSprinting)
                speed = walkSpeed * sprintMultiplier;
            else
                speed = walkSpeed;
            
            Vector3 move = direction.normalized * speed;
            controller.SimpleMove(move);
        }
    }
}