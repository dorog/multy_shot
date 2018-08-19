﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float lookSensitivity = 3f;

    private PlayerMotor motor;

	void Start () {
        motor = GetComponent<PlayerMotor>();
	}
	
	void Update () {
        //Move
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + movVertical).normalized * speed;

        motor.Move(velocity);

        //Rotation: other rotations just for camera
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0f, yRot, 0f) * lookSensitivity;

        //Camera rotation

        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0f, 0f) * lookSensitivity;

        motor.RotateCamera(cameraRotation);
    }
}
