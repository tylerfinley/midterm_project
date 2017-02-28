using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitSplat : MonoBehaviour {

    Vector3 splatLocation;
    public GameObject player;
    HealthManager healthScript;

	void Start () {
        GameObject player = GameObject.Find("Player");
        HealthManager healthScript = player.GetComponent<HealthManager>();
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
