using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVomit : MonoBehaviour {

    public Rigidbody vomit;

	void Start () {
		
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody newVomit = Instantiate(vomit, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z + 1f), Quaternion.identity);
            newVomit.AddForce(Vector3.forward * 10000f);
        }
	}

    void FixedUpdate()
    {
        
    }
}
