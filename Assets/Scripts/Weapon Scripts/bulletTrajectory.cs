using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTrajectory : MonoBehaviour
{
    
    public float speed = 5f;

    void Start()
    {
       
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;    
    }

}
