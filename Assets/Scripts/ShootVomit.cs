using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVomit : MonoBehaviour {

    public Rigidbody vomit;
    public GameObject cam;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody newVomit = Instantiate(vomit, new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z) + cam.transform.forward * 2f, Quaternion.identity) as Rigidbody;
            newVomit.transform.rotation = cam.transform.rotation;
            newVomit.AddForce(cam.transform.forward * 250f);
        }
	}

    void FixedUpdate()
    {
        
    }
}
