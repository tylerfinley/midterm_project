﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootVomit : MonoBehaviour {

    public Rigidbody vomit;
    public GameObject cam;
    public Image greenScreen;
    float alpha;
    public GameObject player;
    HealthManager healthScript;
    public GameObject textPanel;
    public bool vomited = false;

    //test variables
    public float xR;
    public float yR;
    public float zR;


    void Start () {
        alpha = greenScreen.color.a;
        healthScript = player.GetComponent<HealthManager>();
    }
	
	void Update () {
        //shoots vomit forward from way cam is facing
		if (Input.GetKeyDown(KeyCode.Space))
        {
            vomited = true;
            Rigidbody newVomit = Instantiate(vomit, new Vector3(cam.transform.position.x, cam.transform.position.y-.6f, cam.transform.position.z) + cam.transform.forward * 2f, Quaternion.identity) as Rigidbody;
            newVomit.transform.rotation = cam.transform.rotation;
            newVomit.transform.rotation *= Quaternion.Euler(0, -90f, 0);
            newVomit.AddForce(cam.transform.forward * 250f);
            alpha = 0;
            healthScript.currentEnergy -= 50;
        }
        else if (alpha >= 1f)
        {
            alpha = 0f;
            vomited = true;
            Rigidbody newVomit = Instantiate(vomit, new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z) + cam.transform.forward * 2f, Quaternion.identity) as Rigidbody;
            newVomit.transform.rotation = cam.transform.rotation;
            newVomit.AddForce(cam.transform.forward * 250f);
            newVomit.transform.rotation = Quaternion.Euler(0, -90f, 0);
            healthScript.currentEnergy -= 50;
        }
        else
        {
            vomited = false;
        }
        //steadily increases green screen
        if (alpha < 1f && textPanel.activeSelf == false)
        {
            alpha +=.03f * Time.deltaTime;
        }
        greenScreen.color = new Color(greenScreen.color.r, greenScreen.color.g, greenScreen.color.b, alpha);
        //if totally green, reset to no green and vomit
        
        
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Tea")
        {
            Destroy(other.gameObject);
            alpha -= .25f;
        }
    }
}
