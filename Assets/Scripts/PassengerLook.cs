using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerLook : MonoBehaviour {

    public bool lookLeft;
    public bool lookRight;

    float countRotation;

    public Transform targetPlayer;

	void Start () {
        lookLeft = true;
        lookRight = false;
        countRotation = 0f;
	}
	
	void Update () {
        //rotates left and right
        RotateNeck();

        //checks if player is within field of vision
        CheckForPlayer();
    }

    void RotateNeck()
    {
        if (countRotation > 75f)
        {
            countRotation = 0f;
            lookLeft = true;
            lookRight = false;
        }
        if (countRotation < -75f)
        {
            countRotation = 0f;
            lookLeft = false;
            lookRight = true;
        }
        if (lookLeft)
        {
            transform.Rotate(0f, Time.deltaTime * -20f, 0f);
            countRotation += Time.deltaTime * -20f;
        }
        if (lookRight)
        {
            transform.Rotate(0f, Time.deltaTime * 20f, 0f);
            countRotation += Time.deltaTime * 20f;
        }
    }

    void CheckForPlayer()
    {
        Vector3 targetDirection = targetPlayer.position - transform.position;
        float checkedAngle = Vector3.Angle(targetDirection, -transform.right);
        if (checkedAngle < 10f && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("seen by cube");
        }
    }
}
