using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adsCam : MonoBehaviour
{
    public GameObject minigun;
    public GameObject bofor;
    public GameObject howitzer;
    public GameObject e3;

    public Camera cam;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (minigun.activeSelf == true)
        {
            cam.fieldOfView = 10;
        }
        if (bofor.activeSelf == true)
        {
            cam.fieldOfView = 25;
        }
        if (howitzer.activeSelf == true)
        {
            cam.fieldOfView = 50;
        }

        if (e3.activeSelf == true)
        {
            cam.fieldOfView = 65;
        }
    }
}
