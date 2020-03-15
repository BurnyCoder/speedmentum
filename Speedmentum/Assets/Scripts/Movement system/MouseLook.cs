﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;

    //public Transform camera;

    public Transform playerBody; //for rotating the model, which is locked to camera too

    float xRotation = 0f; //for rotating vertically
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity; //Mouse X = how far did the mouse move on the x axis since the last frame, the faster you turn with mouse, the bigger the number is
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity;


        xRotation = xRotation - mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //makes it so that player cannot turn more than 180 degrees

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); //for rotating vertically
                                                                       //not sure how Quaternions work (4d numbers) https://www.youtube.com/watch?v=SCbpxiCN0U0&list=PLW3Zl3wyJwWOpdhYedlD-yCB7WQoHf-My&index=33&t=0s

        playerBody.Rotate(Vector3.up * mouseX); //rotate function changes the rotation vector by the amount in the argument, Vector3.up is shortcut for (0,1,0), so for example 0.15*v=(0;0,15;0)
                                                //same like playerBody.Rotate(new Vector3(0, mouseX, 0));

        //fun!
        //playerBody.Rotate(new Vector3(mouseY, mouseX));
        //playerBody.Rotate(new Vector3(mouseX, mouseX, mouseX));
        //playerBody.Rotate(new Vector3(0, mouseX, mouseX));
        //playerBody.Rotate(new Vector3(0, 0, mouseX));
        //playerBody.Rotate(new Vector3(mouseX, 0, mouseX));

        if (Input.GetKeyDown(KeyCode.L)) //look straight button, using it to find out how many units per second i move each tick
        {
            //playerBody.Rotate(new Vector3(0f, 0f, 0f));
            playerBody.rotation = Quaternion.Euler(0f, 0f, 0f);
            Debug.Log("L");
        }
    }
}
