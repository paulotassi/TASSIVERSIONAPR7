using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float selfDestructTime = 3f; // Time after which the object will destroy itself

    void Start()
    {
        // Invoke the method for self-destruction after the specified time
        Invoke("DestroyObject", selfDestructTime);
    }

    void DestroyObject()
    {
        // Destroy the object
        Destroy(gameObject);
    }
}
