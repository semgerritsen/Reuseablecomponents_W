using System;
using Interfaces;
using UnityEngine;

namespace Movement
{
    public class SwiftMovement : MonoBehaviour, IMovement
    {
        [Header("Movement speeds")]
        [SerializeField] private float walkSpeed       = 5f;
        [SerializeField] private float sprintMultiplier = 1.8f;
        
        private BaseMovement movement;

        // private CharacterController controller;
        
        private void Start()
        {
            // controller = GetComponent<CharacterController>();
            movement = FindAnyObjectByType<BaseMovement>();
        }

        public void Move(Vector3 direction)
        {
            //TODO: Add controller input for sprinting ( idk which button unity recognizes as sprint)
            bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton2);
           
            float speed;
            if (isSprinting)
                speed = walkSpeed * sprintMultiplier;
            else
                speed = walkSpeed;
            
            Vector3 move = direction.normalized * speed;
            movement.controller.SimpleMove(move);
        }
    }
}