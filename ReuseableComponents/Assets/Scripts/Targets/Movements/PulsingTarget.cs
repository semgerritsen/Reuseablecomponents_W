using Base;
using UnityEngine;

namespace Targets
{
    public class PulsingTarget : MonoBehaviour
    {
        [SerializeField] private float amplitude = 0.25f;  // Max scale change (e.g., 0.5 = ±50% of original)
        [SerializeField] private float frequency = 1f;     // Pulses per second

        private Vector3 startScale;

        private void Start()
        {
            startScale = transform.localScale;
        }

        private void Update()
        {
            // Pulsing value goes from -1 to +1
            float pulse = Mathf.Sin(Time.time * frequency);

            // Calculate scale factor (e.g., 1.0 ± amplitude)
            float scaleFactor = 1f + pulse * amplitude;

            // Apply uniform scaling (xyz)
            transform.localScale = startScale * scaleFactor;
        }
    }
}