using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform spawn;
    public GameObject prefab;

    //Bullet Creation
    private GameObject bullet;
    public Transform playerRotation;

    //Ammo Data
    [SerializeField] BCAmmo ammunition;
    [SerializeField] private List<BCAmmo> ammos;
    private bool canShoot;



    private void Start()
    {
        canShoot = true;
            
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ammunition = ammos[0]; //rifle shell
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ammunition = ammos[1]; //shotgun round
            new Vector3 (spawn.position.x + Random.Range(-ammunition.sprd, ammunition.sprd), spawn.position.y + Random.Range(-ammunition.sprd, ammunition.sprd), spawn.position.z + Random.Range(-ammunition.sprd, ammunition.sprd));
        }

    }

    public void Shoot()
    {
      //Raycast for hits
      /*
        Ray ray = new Ray(spawn.position, spawn.forward);
        RaycastHit hit;
        float shotDistance = 25f;
        if (Physics.Raycast(ray,out hit, shotDistance))
        {
            shotDistance = hit.distance;
     

            // Check if the component exists
            if (hit.collider != null && hit.collider.CompareTag("Enemy"))
            {
                // Call a method or access a variable of the component
                Debug.Log("I hit Something");
                hit.collider.GetComponent<Health>().takeDamage(ammunition.dmg);
            }

        } 
      Debug.DrawRay(ray.origin, ray.direction * shotDistance, Color.red, 1f);
      */

        //Spawn Bullet
        if (canShoot == true)
        {
            StartCoroutine(BulletSpawner());
        }
       
    }

    private IEnumerator BulletSpawner()
    {
        for (int j = 0; j < ammunition.rnd; j++)
        {
            bullet = Instantiate(prefab, new Vector3(spawn.position.x + Random.Range(-ammunition.sprd, ammunition.sprd), spawn.position.y + Random.Range(-ammunition.sprd, ammunition.sprd), spawn.position.z + Random.Range(-ammunition.sprd, ammunition.sprd)), Quaternion.identity);
            bullet.transform.rotation = playerRotation.transform.rotation;
        }

        canShoot = false;
        yield return new WaitForSeconds(ammunition.rcol);
        canShoot = true;
    }
}
