using System;
using UnityEngine;

namespace Event
{
    //TODO: Targets needs to be in the center of the target area
    public class TargetHitEffect : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particlePrefab;

        private BaseTarget baseTarget;

        private void Awake()
        {
            baseTarget = GetComponent<BaseTarget>();
            baseTarget.onHit += () => PlayEffect(baseTarget.transform.position);
        }

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