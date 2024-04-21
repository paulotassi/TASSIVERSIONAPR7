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
    public AudioSource asource;
    public AudioClip aClip;
    public float spreadValue;

    //Ammo Data
    [SerializeField] BCAmmo ammunition;
    [SerializeField] private List<BCAmmo> ammos;
    private bool canShoot;



    private void Start()
    {
        canShoot = true;
        asource = GetComponent<AudioSource>();
            
    }

    void Update()
    {
        aClip = ammunition.weaponSound;
        asource.resource = aClip;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ammunition = ammos[0]; //rifle shell
            spreadValue = ammunition.sprd;

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ammunition = ammos[1]; //shotgun round
            spreadValue = ammunition.sprd;
            //new Vector3 (spawn.position.x + Random.Range(-ammunition.sprd, ammunition.sprd), spawn.position.y + Random.Range(-ammunition.sprd, ammunition.sprd), spawn.position.z + Random.Range(-ammunition.sprd, ammunition.sprd));
        }
        

    }

    public void Shoot()
    {

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
            bullet = Instantiate(prefab, new Vector3(spawn.position.x, spawn.position.y , spawn.position.z), Quaternion.identity);
            bullet.transform.rotation = playerRotation.transform.rotation;
        }
        
        asource.Play();
        
        
        
        
        canShoot = false;
        yield return new WaitForSeconds(ammunition.rcol);
        canShoot = true;
    }
}
