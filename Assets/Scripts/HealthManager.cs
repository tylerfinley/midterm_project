using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public int startingEnergy = 200;
    public int currentEnergy;
    public Slider energySlider;
    public GameObject textPanel;
    public GameObject loseText2;

	// Use this for initialization
	void Start () {
        currentEnergy = startingEnergy;
        energySlider.maxValue = 200;
        energySlider.minValue = 0;
        StartCoroutine(GainEnergy());
    }
	
	// Update is called once per frame
	void Update () {
        energySlider.value = currentEnergy;
        //Debug.Log(currentEnergy);
        if (currentEnergy <= 0)
        {
            textPanel.SetActive(true);
            loseText2.SetActive(true);
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Crackers" && currentEnergy <= 80)
        {
            currentEnergy += 50;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Crackers")
        {
            currentEnergy = 200;
            Destroy(other.gameObject);
        }
    }

    private IEnumerator GainEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (currentEnergy < 200)
                currentEnergy += 1;
        }
    }
}
