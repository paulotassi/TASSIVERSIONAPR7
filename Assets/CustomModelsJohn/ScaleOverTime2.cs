using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOverTime2 : MonoBehaviour
{
    public float scaleFactor2 = 0.01f; // Adjust the scale factor on the x-axis as needed

    void Update()
    {
        // Increase the scale of the object over time on the x-axis
        transform.localScale += new Vector3(scaleFactor2 * Time.deltaTime, scaleFactor2 * Time.deltaTime, scaleFactor2 * Time.deltaTime);
    }
}
