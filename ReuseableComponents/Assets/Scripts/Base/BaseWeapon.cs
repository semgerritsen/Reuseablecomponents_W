using Interfaces;
using UnityEngine;

namespace Weapons
{
    public class BaseWeapon : MonoBehaviour, IWeapon
    {
        [Header("Weapon Settings")] [SerializeField]
        private GameObject bulletPrefab;

        [SerializeField] private float bulletSpeed = 100f;
        [SerializeField] private float damage = 1f;
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
            
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            Vector3 targetDirection = ray.direction;
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(targetDirection));
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = targetDirection.normalized * bulletSpeed;
            }
        }
    }
}