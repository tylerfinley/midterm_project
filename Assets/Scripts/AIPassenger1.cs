using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPassenger1 : MonoBehaviour {

    public Transform vomitTarget;
    public float walkSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float step = walkSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, vomitTarget.position, step);
	}
}
