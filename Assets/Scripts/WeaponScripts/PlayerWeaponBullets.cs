using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponBullets : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 1f;
    [SerializeField] BCAmmo ammunition;
    [SerializeField] float spreadValue;
    [SerializeField] private List<BCAmmo> ammos;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
               
    }

    private void Awake()
    {
        spreadValue = GameObject.Find("Weapon").GetComponent<PlayerWeapon>().spreadValue;
    }

    private void FixedUpdate()
    {
        spreadValue = GameObject.Find("Weapon").GetComponent<PlayerWeapon>().spreadValue;
     
        transform.position += transform.TransformVector(Random.Range(-spreadValue, spreadValue) , Random.Range(-spreadValue, spreadValue), bulletSpeed) ;
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
        Debug.Log(spreadValue);
        Destroy(gameObject);
    }
}
