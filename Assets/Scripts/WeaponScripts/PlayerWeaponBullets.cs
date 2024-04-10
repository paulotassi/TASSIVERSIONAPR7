using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponBullets : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 1f;
    [SerializeField] BCAmmo ammunition;
    [SerializeField] private List<BCAmmo> ammos;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * bulletSpeed;

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("I hit Something");
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
