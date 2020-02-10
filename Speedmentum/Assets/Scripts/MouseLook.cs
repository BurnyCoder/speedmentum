﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    
    public Transform playerBody; //for rotating the model, which is locked to camera too

    float xRotation = 0f; //for rotating vertically
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Mouse X = how far did the mouse move on the x axis since the last frame, the faster you turn with mouse, the bigger the number is
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //makes it so that player cannot turn more than 180 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //for rotating vertically
        //not sure how Quaternions work (4d numbers) https://www.youtube.com/watch?v=SCbpxiCN0U0&list=PLW3Zl3wyJwWOpdhYedlD-yCB7WQoHf-My&index=33&t=0s

        playerBody.Rotate(Vector3.up * mouseX); //rotate function changes the rotation vector by the amount in the argument, Vector3.up is shortcut for (0,1,0), so for example 0.15*v=(0;0,15;0)
        
        
        
        
        //Debug.Log(Input.GetAxis("Mouse X"));
        //Debug.Log(Vector3.up * mouseX);
        //Debug.Log(Vector3.up);
        //Debug.Log(mouseX);
    }
}
