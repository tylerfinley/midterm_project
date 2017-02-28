using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour {

    public GameObject textPanel;
    public GameObject startText;
    public GameObject loseText;
    public GameObject winText;

	void Start () {
        Time.timeScale = .000000000001f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.F) && Time.timeScale < 1f)
        {
            textPanel.SetActive(false);
            startText.SetActive(false);
            Time.timeScale = 1f;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Backpack")
        {
            textPanel.SetActive(true);
            winText.SetActive(true);
        }
    }
}
