using System;
using UnityEngine;

namespace Event
{
    public class TargetHitEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particlePrefab;

        private BaseTarget baseTarget;

        private void Awake()
        {
            baseTarget = GetComponent<BaseTarget>();
            baseTarget.onHit += () => PlayEffect(baseTarget.transform.position);
        }

        /// <summary>
        ///  Plays the particle effect at the specified position of the basetarget.
        /// </summary>
        /// <param name="position"></param>
        private void PlayEffect(Vector3 position)
        {
            if (particlePrefab != null)
            {
                ParticleSystem effect = Instantiate(particlePrefab, position, Quaternion.identity);
                effect.Play();

                Destroy(effect.gameObject, effect.main.duration + effect.main.startLifetime.constantMax);
            }
        }

        private void OnDestroy()
        {
            if (baseTarget != null)
            {
                baseTarget.onHit -= () => PlayEffect(baseTarget.transform.position);
            }
        }
    }
}