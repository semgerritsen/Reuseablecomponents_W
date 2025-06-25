using System;
using Interfaces;
using UnityEngine;

namespace Base
{
    public class TargetBaseMovement : MonoBehaviour, IMovement
    {
        [SerializeField] float moveSpeed = 2f;

        public void Move(Vector3 direction)
        {
            transform.position += direction.normalized * (moveSpeed * Time.deltaTime);
        }
    }
}