using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeaponBullets : MonoBehaviour
{
    [SerializeField] public float bulletSpeed = 1f;
    [SerializeField] BCAmmo ammunition;
    [SerializeField] float intialSpreadValue;
    [SerializeField] float currentSpreadAmount;

    [SerializeField] private List<BCAmmo> ammos;

    private void Start()
    {
        StartCoroutine(SelfDestruct());
               
    }

    private void Awake()
    {
        intialSpreadValue = GameObject.Find("Weapon").GetComponent<PlayerWeapon>().spreadValue;
        currentSpreadAmount = Random.Range(-intialSpreadValue, intialSpreadValue);
 
        
    }

    private void FixedUpdate()
    {
        //intialSpreadValue = GameObject.Find("Weapon").GetComponent<PlayerWeapon>().spreadValue;
     
        transform.position += transform.TransformVector(currentSpreadAmount , 0, bulletSpeed) ;
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
        //Debug.Log(spreadValue);
        Destroy(gameObject);
    }
}
