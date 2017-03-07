using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitSplat : MonoBehaviour {

    Vector3 splatLocation;
    public GameObject player;
    HealthManager healthScript;
    public GameObject vomitSplat;

	void Start () {
        //GameObject player = GameObject.Find("Player");
        HealthManager healthScript = player.GetComponent<HealthManager>();
    }

	void Update () {
		
	}

    void OnCollisionEnter (Collision other)
    {
        if (other.gameObject != GameObject.Find("Player"))
        {
            splatLocation = other.contacts[0].point;
            Debug.Log(other.gameObject);
            var newSplat = Instantiate(vomitSplat, new Vector3(splatLocation.x, splatLocation.y + .1f, splatLocation.z), other.gameObject.transform.rotation);
            Destroy(gameObject, .01f);  
        }
    }
}
