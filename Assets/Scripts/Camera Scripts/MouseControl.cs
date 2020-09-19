using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    //Mouse Input Variables
    public Transform playerBody;
    public float mouseSense = 100f;
    float xRotation = 0f;

    //Funciton Definition Below
    void Start()
    {
        //Sets Cursor to center and hides it
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Update Definition Below
    void Update()
    {
        //Gets Input of Mouse Movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSense * Time.deltaTime;

        xRotation -= mouseY; //Decrease X Rotation based on our Mouse Y because + flips it
       
        xRotation = Mathf.Clamp(xRotation, 15f, 60f); //Clamping Y rotation of Player's Control

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //Tracks X Rotation
        
        playerBody.Rotate(Vector3.up * mouseX); //Specify Access to rotate around

    }
}
