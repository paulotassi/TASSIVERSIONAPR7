using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace weapons
{
public class Shooting : MonoBehaviour
{
        [SerializeField] BCAmmo ammunition;
        [SerializeField] private List<BCAmmo> ammos;
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ammunition = ammos[0]; //shotgun shell
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ammunition = ammos[1]; //rifle round
            }
        if(Input.GetMouseButton(0))
            {
                shoot();
                Debug.Log("ShotSomething");
            }

    }
    private void shoot()
        {

            Vector3 mpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mpos.z = 0;

            if (ammunition == ammos[0]) //shooting with shotgun equiped
            {
                mpos = new Vector3(mpos.x * Random.Range(-1f, 1f) * ammunition.sprd, mpos.y * Random.Range(-1f, 1f) * ammunition.sprd);
                Vector3 aimVec = (mpos - transform.position).normalized;

            }
            if (ammunition == ammos[1]) //shooting with rifle rounds
            {
     
               mpos = new Vector3(mpos.x * Random.Range(-1f, 1f) * ammunition.sprd, mpos.y * Random.Range(-1f, 1f) * ammunition.sprd);
               Vector3 aimVec = (mpos - transform.position).normalized;
               if (Physics.Raycast(transform.position, aimVec, out RaycastHit hit))
                {
                    
                }
            }
        }
}
}