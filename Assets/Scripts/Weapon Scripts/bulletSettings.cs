using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //public float dieTime = 5f;
    public GameObject collisionExplosion;
    void Start()
    {
        //Destroy(gameObject, dieTime);
    }

    void Update()
    {
                
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object" || collision.gameObject.tag == "Ground")
        {
            GameObject explosion = (GameObject)Instantiate(collisionExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 5f);
            return;
        }
    }
}
