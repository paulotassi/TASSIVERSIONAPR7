using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] public GameObject playerPosition;
    [SerializeField] public Vector3 targetCameraPosition;
    [SerializeField] public float camZoomAdjust = 1f;
    [SerializeField] private float newCamHeight;
    [SerializeField] private float newCamZ;

    private void Start()
    {

        //create initial zamera height from gameobject

        newCamHeight = gameObject.transform.position.y;

        //if Designer changes zoom of camera object it will change the height to keep player in proper position on screen
        if (camZoomAdjust > 1)
        {
            newCamHeight = transform.position.y + camZoomAdjust;
            

        }
    }
    private void Update()
    {
        newCamZ = playerPosition.transform.position.z - 8f - camZoomAdjust;
        targetCameraPosition = new Vector3(playerPosition.gameObject.transform.position.x , newCamHeight, newCamZ);

        //Camera offset on player and chanes position to match but locks the rotation
        //targetCameraPosition = new Vector3((playerPosition.gameObject.transform.position.x ) - camZoomAdjust, newCamHeight, (playerPosition.gameObject.transform.position.z) - camZoomAdjust);
        transform.position = targetCameraPosition;
    }
}