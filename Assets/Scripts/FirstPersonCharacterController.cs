using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterController : MonoBehaviour {

    CharacterController playerController;
    public float movementSpeed = 10;
    public GameObject player;
    HealthManager healthScript;
    

    void Start () {
        playerController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        healthScript = player.GetComponent<HealthManager>();
    }
	
	// Update is called once per frame
	void Update () {
        // grab input for movement
        float horizontal = Input.GetAxis("Horizontal"); // left and right
        float vertical = Input.GetAxis("Vertical");

        //hold shift to move faster
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed *= 2f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed *= .5f;
        }

        //lower energy for running
        if (movementSpeed > 19f)
        {
            healthScript.currentEnergy -= 1;
        }

        //plug values into controller
        playerController.Move(transform.forward * Time.deltaTime * vertical * movementSpeed);
        playerController.Move(transform.right * Time.deltaTime * horizontal * movementSpeed);

        //add gravity
        playerController.Move(Physics.gravity * .01f);

        //turning
        //transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * 180f, 0f);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
