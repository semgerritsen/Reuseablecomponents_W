using Base;
using Interfaces;
using UnityEngine;

namespace Targets
{
    public class VerticalTarget : MonoBehaviour
    {
        [SerializeField] private float amplitude = 2f;
        [SerializeField] private float frequency = 1f;
        
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

        private void Update()
        {
            float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
            Vector3 targetPosition = startPosition + Vector3.up * yOffset;
            Vector3 direction = targetPosition - transform.position;
            movement.Move(direction);
        }
    }
}