using System;
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
        
        private IAimInput aimInput;
        private IWeaponInput weaponInput;

        private void Start()
        {
            aimInput = GetComponent<IAimInput>();
            weaponInput = GetComponent<IWeaponInput>();
        }

        private void Update()
        {
            // omdat baseweapon al bestaat voor de controllerinput en mouseaiminput, komt er een nullreference error. dit is niet de meest effieciënte manier, maar het werkt wel
            if (CheckAimInput()) return;
            if (CheckWeaponInput()) return;

            if (weaponInput != null && weaponInput.IsFiring() && Time.time >= nextFireTime)
            {
                Debug.Log(weaponInput.IsFiring());
                Fire();
                nextFireTime = Time.time + fireRate;
            }
        }

        private bool CheckAimInput()
        {
            if (aimInput == null)
            {
                aimInput = GetComponent<IAimInput>();
                if (aimInput == null) return true;
            }

            return false;
        }
        private bool CheckWeaponInput()
        {
            if (weaponInput == null)
            {
                weaponInput = GetComponent<IWeaponInput>();
                if (weaponInput == null) return true;
            }

            return false;
        }

        public void Fire()
        {
            if (bulletPrefab == null || firePoint == null) return;

            Ray aimRay = aimInput.GetAimDirection();
            
            Vector3 targetPoint = aimRay.origin + aimRay.direction * bulletSpeed;
            Vector3 direction = (targetPoint - firePoint.position).normalized;
            
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            
            bulletRb.linearVelocity = direction * bulletSpeed;
            
            Destroy(bullet, 3f);
        }
    }
}