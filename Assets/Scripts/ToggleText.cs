using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// script to change text of sound and save point toggle buttons to match settings
// this script runs once a scene loads, ensures correct text is shown
public class ToggleText : MonoBehaviour
{
	private GameManager gameManagerScript;
	public TextMeshProUGUI textComponent;
	
    // Start is called before the first frame update
    void Start()
    {
		// change text to match current settings
        this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		if(gameObject.name == "SoundButton")
		{
			if(gameManagerScript.getVolume())
			{
				textComponent.text = "Sound ON";
			}
			else
			{
				textComponent.text = "Sound OFF";
			}
		}
		else if(gameObject.name == "SavePointButton")
		{
			if(gameManagerScript.getSavePointsEnabled())
			{
				textComponent.text = "Save Points ON";
			}
			else
			{
				textComponent.text = "Save Points OFF";
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
