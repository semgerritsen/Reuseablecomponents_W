using System;
using Movement;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider _player)
    {
        if (_player.gameObject.CompareTag("Player"))
        {
            _player.gameObject.AddComponent<SwiftMovement>();
            Destroy(this);
        }
    }
}
