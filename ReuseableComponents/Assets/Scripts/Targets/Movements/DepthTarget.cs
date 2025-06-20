using System;
using Base;
using UnityEngine;


namespace Targets
{
    public class DepthTarget : TargetBaseMovement
    {
        [SerializeField] private float moveSpeed = 2f;
        [SerializeField] private float amplitude = 5f;
        [SerializeField] private float frequency = 1f;
        
        private TargetBaseMovement baseMovement;
        // Override the moveSpeed from TargetBaseMovement
        
        private Vector3 startPosition;

        private void Awake()
        {
            baseMovement = GetComponent<TargetBaseMovement>();
            
        }

        private void Start()
        {
            startPosition = transform.position;
            baseMovement.MoveSpeed = moveSpeed; // Set the move speed from the inspector
        }

        private void Update()
        {
            float xOffset = Mathf.Sin(Time.time * frequency) * amplitude;
            Vector3 targetPosition = startPosition + Vector3.back * xOffset;
            Vector3 direction = targetPosition - transform.position;
            Move(direction);
        }
    }
}