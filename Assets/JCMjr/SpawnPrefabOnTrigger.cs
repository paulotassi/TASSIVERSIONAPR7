using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPrefabOnTrigger : MonoBehaviour
{
    public GameObject prefabToSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("NoBoom")) // Change "Player" to the tag of the object you want to trigger the spawn
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
