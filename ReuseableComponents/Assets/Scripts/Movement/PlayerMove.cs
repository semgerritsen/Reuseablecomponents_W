﻿using Interfaces;
using UnityEngine;

namespace Movement
{
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
            
            Vector3 dir = transform.TransformDirection(movementInput.GetMovementDirection());
            movement.Move(dir);
        }
    }
}