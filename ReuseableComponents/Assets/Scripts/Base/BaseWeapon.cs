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
        
        // Interfaces for input handling
        private IAimInput aimInput;
        private IWeaponInput weaponInput;

        //search for the interfaces in the gameobject
        private void Start()
        {
            aimInput = GetComponent<IAimInput>();
            weaponInput = GetComponent<IWeaponInput>();
        }

        private void Update()
        {
            // Since BaseWeapon already exists before ControllerInput and MouseAimInput, a NullReference error occurs. This isn't the most efficient way, but it does work — the same applies to WeaponInput.
            if (CheckAimInput()) return;
            if (CheckWeaponInput()) return;

            // Check if the weapon is firing based on the input method chosen and if enough time has passed since the last shot
            if (weaponInput != null && weaponInput.IsFiring() && Time.time >= nextFireTime)
            {
                // Fire the weapon
                Fire();
                // Reset the next fire time based on the fire rate
                nextFireTime = Time.time + fireRate;
            }
        }

        private bool CheckAimInput()
        {
            // If aimInput is not set, try to find it on the same GameObject
            if (aimInput == null)
            {
                aimInput = GetComponent<IAimInput>();
                if (aimInput == null) return true;
            }
            // If aimInput is still null, it means the component was not found
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
            // Ensure that the bulletPrefab and firePoint are set before firing
            if (bulletPrefab == null || firePoint == null) return;

            // Get the aim direction from the input interface
            Ray aimRay = aimInput.GetAimDirection();
            
            // Calculate the target point based on the aim direction and bullet speed
            Vector3 targetPoint = aimRay.origin + aimRay.direction * bulletSpeed;
            // Calculate the direction from the fire point to the target point
            Vector3 direction = (targetPoint - firePoint.position).normalized;
            // Instantiate the bullet at the fire point and set its velocity
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            // Get the Rigidbody component of the bullet
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            
            // set the bullet's velocity in the direction of the aim
            bulletRb.linearVelocity = direction * bulletSpeed;
            
            //destory the bullet after 3 seconds to prevent memory leaks
            Destroy(bullet, 3f);
        }
    }
}