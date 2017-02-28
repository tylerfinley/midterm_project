﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour {

    CharacterController playerController;
    public float movementSpeed;

	void Start () {
        playerController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        // grab input for movement
        float horizontal = Input.GetAxis("Horizontal"); // left and right
        float vertical = Input.GetAxis("Vertical");

        //plug values into controller
        playerController.Move(transform.forward * Time.deltaTime * vertical * movementSpeed);
        playerController.Move(transform.right * Time.deltaTime * horizontal * movementSpeed);

        //add gravity
        playerController.Move(Physics.gravity * .01f);

        //turning
        transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * 180f, 0f);
    }
}