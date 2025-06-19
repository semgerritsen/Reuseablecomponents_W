using System;
using UnityEngine;

namespace Targets
{
    public class CollisionHandler : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            Debug.Log("Rigidbody collision detected with: " + other.gameObject.name);
        }
    }
}