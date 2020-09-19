using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clampScript : MonoBehaviour
{
    //Clamps Rotation for player camera
    float xRotation = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        xRotation = Mathf.Clamp(xRotation, 15f, 60f);
    }
}
