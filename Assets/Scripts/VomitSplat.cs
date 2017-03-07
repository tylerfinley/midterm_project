using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VomitSplat : MonoBehaviour {

    Vector3 splatLocation;
    public GameObject splatPlacement;
    GameObject player;
    HealthManager healthScript;
    public GameObject vomitSplat;

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
            splatPlacement.transform.position = splatLocation;
            //Debug.Log(splatLocation);
            Destroy(gameObject, .5f);
            Debug.Log(splatPlacement.transform.position);
            GameObject newVomitSplat = Instantiate(vomitSplat, splatPlacement.transform) as GameObject;
        }
    }
}
