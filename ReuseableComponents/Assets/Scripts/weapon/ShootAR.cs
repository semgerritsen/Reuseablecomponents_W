using UnityEngine;

public class ShootAR : MonoBehaviour
{
    [Header("Bullet Settings")]
    public GameObject bulletPrefab;      // Your bullet prefab
    public Transform firePoint;          // The spawn point for bullets
    public float bulletForce = 20f;      // Speed of the bullet

    [Header("Fire Settings")]
    public float fireRate = 0.5f;        // Time between shots
    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }
}