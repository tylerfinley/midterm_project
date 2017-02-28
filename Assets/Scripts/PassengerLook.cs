using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerLook : MonoBehaviour {

    public bool lookLeft;
    public bool lookRight;

    public float rotationSpeed;
    public float rotationAmount;

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
        if (countRotation > rotationAmount)
        {
            countRotation = 0f;
            lookLeft = true;
            lookRight = false;
        }
        if (countRotation < -rotationAmount)
        {
            countRotation = 0f;
            lookLeft = false;
            lookRight = true;
        }
        if (lookLeft)
        {
            transform.Rotate(0f, Time.deltaTime * -rotationSpeed, 0f);
            countRotation += Time.deltaTime * -rotationSpeed;
        }
        if (lookRight)
        {
            transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
            countRotation += Time.deltaTime * rotationSpeed;
        }
    }

    void CheckForPlayer()
    {
        //angle of vision
        Vector3 targetDirection = targetPlayer.position - transform.position;
        float checkedAngle = Vector3.Angle(targetDirection, -transform.right);
        if (checkedAngle < 45f)
        {
            inAngle = true;
        }
        else
        {
            inAngle = false;
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

        
        

        //lose State
        if (vomitScript.vomited == true && inRange && inAngle && inSight && textPanel.activeSelf == false)
        {
            StartCoroutine(LoseGame());
            
        }

        //change AI color if all conditions met to be "seen"
        if(inRange && inAngle && inSight)
        {
            GetComponent<Renderer>().material.color = new Color(0f, 1f, 1f);
        }
        else
        {
            GetComponent<Renderer>().material.color = startColor;
        }
    }
    //wait to see vomit spew before losing
    private IEnumerator LoseGame()
    {
        yield return new WaitForSeconds(1.25f);
        Debug.Log("seen by cube");
        textPanel.SetActive(true);
        loseText.SetActive(true);
    }
    //raycasts are physics-based
    void FixedUpdate()
    {
        //Raycast to see if in sight
        if (inAngle)
        {
            Ray ray = new Ray(transform.position, (player.transform.position - transform.position).normalized);

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
        }
    }
}
