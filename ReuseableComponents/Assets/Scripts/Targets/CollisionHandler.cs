using System;
using UnityEngine;


//TODO: when hit, event for particle system to play according to the color of the target    
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
            // if (baseTarget != null)
            // {
            //     baseTarget.OnHit();
            // }
            Destroy(collision.gameObject);
        }
    }
}