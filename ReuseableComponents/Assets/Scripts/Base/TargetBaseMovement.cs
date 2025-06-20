using System;
using UnityEngine;

namespace Base
{
    public class TargetBaseMovement : MonoBehaviour
    {
        protected float moveSpeed;
        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }

        public void Move(Vector3 direction)
        {
            transform.position += direction.normalized * (moveSpeed * Time.deltaTime);
            Console.WriteLine("Moving in direction: " + direction.normalized + " with speed: " + moveSpeed);
        }
    }
}