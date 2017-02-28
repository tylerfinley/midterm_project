using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootVomit : MonoBehaviour {

    public Rigidbody vomit;
    public GameObject cam;
    public Image greenScreen;
    float alpha;

	void Start () {
        alpha = greenScreen.color.a;
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody newVomit = Instantiate(vomit, new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z) + cam.transform.forward * 2f, Quaternion.identity) as Rigidbody;
            newVomit.transform.rotation = cam.transform.rotation;
            newVomit.AddForce(cam.transform.forward * 250f);
        }
        if (alpha < 1f)
        {
            alpha += .0003f;
        }
        greenScreen.color = new Color(greenScreen.color.r, greenScreen.color.g, greenScreen.color.b, alpha);
        if (alpha >= 1f)
        {
            alpha = 0f;
            Rigidbody newVomit = Instantiate(vomit, new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z) + cam.transform.forward * 2f, Quaternion.identity) as Rigidbody;
            newVomit.transform.rotation = cam.transform.rotation;
            newVomit.AddForce(cam.transform.forward * 250f);
        }
	}

    void FixedUpdate()
    {
        
    }
}
