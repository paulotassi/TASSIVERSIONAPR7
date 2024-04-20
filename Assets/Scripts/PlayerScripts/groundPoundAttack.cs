using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundPoundAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
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
            if (Input.GetKeyDown(KeyCode.E)) // Change to any desired input key
            {
                GroundSlam();
                delay = seconds;
            }
        }
    }

    void GroundSlam ()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = firePoint.forward * projectileSpeed; // Assuming the projectile moves along the object's forward direction
        }
        else
        {
            Debug.LogError("Rigidbody not found on projectile prefab.");
        }
    }
}