using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitSplat : MonoBehaviour {

    Vector3 splatLocation;
    public GameObject player;

	void Start () {
		
	}

	void Update () {
		
	}

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject != player)
        {
            splatLocation = other.contacts[0].point;
            //Debug.Log(splatLocation);
            Destroy(gameObject, .1f);
        }
    }
}
