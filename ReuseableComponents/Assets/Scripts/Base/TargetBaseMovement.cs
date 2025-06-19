using System;
using UnityEngine;

namespace Base
{
    public class TargetBaseMovement : MonoBehaviour
    {
        [SerializeField] protected float moveSpeed = 2f;

        public void Move(Vector3 direction)
        {
            transform.position += direction.normalized * (moveSpeed * Time.deltaTime);
            Console.WriteLine("Moving in direction: " + direction.normalized + " with speed: " + moveSpeed);
        }
    }
}