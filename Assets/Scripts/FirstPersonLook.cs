using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonLook : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
        transform.Rotate(Input.GetAxis("Mouse Y") * Time.deltaTime * 60f, 0f, 0f);
	}
}
