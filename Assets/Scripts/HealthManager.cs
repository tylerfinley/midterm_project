using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public int startingEnergy = 100;
    public int currentEnergy;
    public Slider energySlider;

	// Use this for initialization
	void Start () {
        currentEnergy = startingEnergy;
	}
	
	// Update is called once per frame
	void Update () {
        energySlider.value = currentEnergy;
        //Debug.Log(currentEnergy);
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crackers" && currentEnergy <= 80)
        {
            currentEnergy += 20;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Crackers")
        {
            currentEnergy = 100;
            Destroy(other.gameObject);
        }
    }
}
