using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPoundAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public GameObject projectilePrefab2;
    public Transform firePoint2;
    public float projectileSpeed2 = 10f;
    public GameObject projectilePrefab3;
    public Transform firePoint3;
    public float projectileSpeed3 = 10f;
    public float seconds = 5;
    public float delay;

    void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        if (delay <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space)) // Change to any desired input key
            {
                Shoot();
                delay = seconds;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0)) // Change to any desired input key
        {
            Shoot2();
        }
        if (Input.GetKeyDown(KeyCode.E)) // Change to any desired input key
        {
            Shoot3();
        }
    }

    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * projectileSpeed; // Assuming the projectile moves along the object's forward direction
        }
        else
        {
            Debug.LogError("Rigidbody not found on projectile prefab.");
        }
    }