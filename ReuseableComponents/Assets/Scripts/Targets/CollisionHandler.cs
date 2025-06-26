using System;
using UnityEngine;


namespace Targets
{
    public class CollisionHandler : MonoBehaviour
    {
        private BaseTarget baseTarget;

        private void Awake()
        {
            baseTarget = GetComponent<BaseTarget>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (baseTarget != null)
            {
                baseTarget.OnHit();
            }
            Destroy(collision.gameObject);
        }
    }
}