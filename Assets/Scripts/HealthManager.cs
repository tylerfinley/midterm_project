using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {
    public float startingEnergy = 100f;
    public float currentEnergy;
    public Slider energySlider;
    public GameObject textPanel;
    public GameObject loseText2;

	// Use this for initialization
	void Start () {
        currentEnergy = startingEnergy;
        energySlider.maxValue = 100f;
        energySlider.minValue = 0f;
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
        if(other.gameObject.tag == "Crackers" && currentEnergy <= 50f)
        {
            currentEnergy += 50f;
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Crackers")
        {
            currentEnergy = 100f;
            Destroy(other.gameObject);
        }
    }

    private IEnumerator GainEnergy()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (currentEnergy < 100f)
                currentEnergy += .25f * Time.deltaTime;
        }
    }
}
