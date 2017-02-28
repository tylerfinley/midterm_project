using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerLook : MonoBehaviour {

    public bool lookLeft;
    public bool lookRight;

    float countRotation;

    public Transform targetPlayer;

    bool inAngle;
    bool inSight;
    bool inRange;

    public GameObject player;

    public GameObject loseText;
    public GameObject textPanel;

    Color startColor;

    ShootVomit vomitScript;

    void Start () {
        lookLeft = true;
        lookRight = false;
        countRotation = 0f;
        startColor = GetComponent<Renderer>().material.color;
        vomitScript = player.GetComponent<ShootVomit>();
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
        if (checkedAngle < 30f)
        {
            inAngle = true;
        }

        float distance = Mathf.Abs(Vector3.Distance(targetPlayer.position, transform.position));
        if (distance < 25f)
        {
            inRange = true;
        }
        else
        {
            inRange = false;
        }

        //Raycast to see if in sight, but how to do more than one???
        Ray ray = new Ray(transform.position, -transform.right);

        RaycastHit rayHit = new RaycastHit();

        Debug.DrawRay(ray.origin, ray.direction * 30f, Color.yellow);

        if (Physics.Raycast(ray, out rayHit, 30f))
        {
            var currentlyHit = rayHit.collider;
            if (currentlyHit.gameObject == player)
            {
                inSight = true;
            }
            else
            {
                inSight = false;
            }
            
        }

        //lose State
        if (vomitScript.vomited == true && inRange && inAngle)
        {
            Debug.Log("seen by cube");
            textPanel.SetActive(true);
            loseText.SetActive(true);
        }
        if(inRange && inAngle)
        {
            GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
        }
        else
        {
            GetComponent<Renderer>().material.color = startColor;
        }
    }
}
