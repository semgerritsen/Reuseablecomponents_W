using System;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace
{
    public class BaseHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float maxHealth = 3;
        [SerializeField] private float health;

        public void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                // event for death
            }
        }

        public void Heal(float amount)
        {
            health += amount;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }
}