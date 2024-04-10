using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] BCAmmo ammunition;
    [SerializeField] private List<BCAmmo> ammos;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("I hit the player");
            other.gameObject.GetComponent<Health>().takeDamage(ammunition.dmg);
            Destroy(gameObject);

        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
