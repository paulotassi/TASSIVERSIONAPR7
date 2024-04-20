using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPush : MonoBehaviour
{
    public float pushForce = 10f; // The force to push the object up

    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger has a Rigidbody
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Apply upward force to the object
            // rb.AddForce(Vector3.back * pushForce, ForceMode.Impulse);
            Vector3 dir = (other.transform.position - transform.position).normalized;
            rb.AddForce(dir * pushForce, ForceMode.Impulse);
        }
    }
}