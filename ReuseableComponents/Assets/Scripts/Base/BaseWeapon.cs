using System;
using Interfaces;
using UnityEngine;

//TODO: when x amount of bullets are fired, play reload animation so player cant spam 
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
        private IAimInput aimInput;

        private void Start()
        {
            aimInput = GetComponent<IAimInput>();
        }

        private void Update()
        {
            // omdat baseweapon al bestaat voor de controllerinput en mouseaiminput, komt er een nullreference error. dit is niet de meest effieciënte manier, maar het werkt wel
            if (aimInput == null)
            {
                aimInput = GetComponent<IAimInput>();
                if (aimInput == null) return;
            }
            
            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                Fire();
                nextFireTime = Time.time + fireRate;
            }
        }
        
        public void Fire()
        {
            if (bulletPrefab == null || firePoint == null) return;

            Ray aimRay = aimInput.GetAimDirection();
            
            Vector3 targetPoint = aimRay.origin + aimRay.direction * bulletSpeed;
            Vector3 direction = (targetPoint - firePoint.position).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = direction * bulletSpeed;
            }
            else
            {
                Debug.LogWarning("Bullet prefab does not have a Rigidbody component.");
            }
            
        }
    }
}