using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class groundPoundAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;
    public UnityEvent shieldBust;
    public float seconds = 5;
    public float delay;
    public string tagThatTriggers = "Boss";

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
                groundPound();
                delay = seconds;
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagThatTriggers)
        {
            shieldBust.Invoke();
        }
    }
    public void groundPound()
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