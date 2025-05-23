using System;
using Interfaces;
using UnityEngine;

namespace DefaultNamespace
{
    public class BaseHealth : MonoBehaviour, IHealth
    {
        [SerializeField] float maxHealth = 3;
        [SerializeField] float health;

        public void Start()
        {
            health = maxHealth;
        }

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
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