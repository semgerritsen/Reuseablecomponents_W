using System;
using Base;
using Interfaces;
using UnityEngine;


namespace Targets
{
    public class DepthTarget : MonoBehaviour
    {
        [SerializeField] private float amplitude = 5f;
        [SerializeField] private float frequency = 1f;

        // Override the moveSpeed from TargetBaseMovement

        private Vector3 startPosition;

        private IMovement movement;

        private void Awake()
        {
            movement = GetComponent<IMovement>();
        }

        private void Start()
        {
            startPosition = transform.position;
        }

        // Called once per frame to update the target's position
        private void Update()
        {
            // Calculate the offset along the Z-axis using a sine wave
            float xOffset = Mathf.Sin(Time.time * frequency) * amplitude;

            // Determine the new target position based on the starting position and calculated offset
            Vector3 targetPosition = startPosition + Vector3.back * xOffset;

            // Calculate the direction  from the current position to the target position
            Vector3 direction = targetPosition - transform.position;

            // Move the target in the calculated direction using the movement component
            movement.Move(direction);
        }
    }
}