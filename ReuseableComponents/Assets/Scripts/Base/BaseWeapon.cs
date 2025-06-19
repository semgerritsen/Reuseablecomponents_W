using Interfaces;
using UnityEngine;

namespace Weapons
{
    public class BaseWeapon : MonoBehaviour, IWeapon
    {
        [Header("Weapon Settings")] [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private float fireRate = 0.5f;
        [SerializeField] Transform firePoint;
        private float nextFireTime = 0f;

        private void Update()
        {
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }
        }
        
        public void Fire()
        {
            if (bulletPrefab == null || firePoint == null) return;

            // Cast a ray from the center of the screen (crosshair)
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            // Calculate the target point (a far point in the ray direction)
            Vector3 targetPoint = ray.origin + ray.direction * 1000f;

            // Calculate direction from the firePoint (gun) to that target point
            Vector3 direction = (targetPoint - firePoint.position).normalized;

            // Instantiate the bullet at the firePoint and rotate it to face the target
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));

            // Apply velocity
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = direction * bulletSpeed;
            }
            
        }
    }
}