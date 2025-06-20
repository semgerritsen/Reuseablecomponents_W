using System;
using Base;
using UnityEngine;


namespace Targets
{
    public class DepthTarget : TargetBaseMovement
    {
        [SerializeField] private float amplitude = 5f;
        [SerializeField] private float frequency = 1f;
        
        // Override the moveSpeed from TargetBaseMovement
        
        private Vector3 startPosition;

        private void Awake()
        {
            
        }

        private void Start()
        {
            startPosition = transform.position;
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