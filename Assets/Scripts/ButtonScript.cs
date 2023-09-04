using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// script for buttons on GUI screens
public class ButtonScript : MonoBehaviour
{
	private GameManager gameManagerScript;
	//public AudioClip buttonClip;
	//AudioSource audioSource;
	
    // Start is called before the first frame update
    void Start()
    {
        this.gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
		//this.audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	// these functions load the corresponding scene
	public void LoadCharSelection()
	{
		this.gameManagerScript.PlayButtonClip();
		SceneManager.LoadScene("CharSelect Screen");
	}
	
	public void LoadArena()
	{
		this.gameManagerScript.PlayButtonClip();
		this.gameManagerScript.StartGame();
		//SceneManager.LoadScene("Air Arena");
	}
	
	public void LoadControls()
	{
		this.gameManagerScript.PlayButtonClip();
		SceneManager.LoadScene("Controls Screen");
	}
	
	public void LoadStartScreen()
	{
		this.gameManagerScript.PlayButtonClip();
		SceneManager.LoadScene("Start Screen");
	}
	
	public void LoadEndScreen()
	{
		this.gameManagerScript.PlayButtonClip();
		SceneManager.LoadScene("End Screen");
	}
	
	public void LoadInstructionScreen()
	{
		this.gameManagerScript.PlayButtonClip();
		SceneManager.LoadScene("Instructions Screen");
	}
	
	public void LoadSettingsScreen()
	{
		this.gameManagerScript.PlayButtonClip();
		SceneManager.LoadScene("Settings Screen");
	}
	
	public void Quit()
	{
		this.gameManagerScript.PlayButtonClip();
		Application.Quit();
	}
	
	// triggered when player selects a character
	public void SelectCharacter(string character)
	{
		this.gameManagerScript.PlayButtonClip();
		this.gameManagerScript.SetCharacter(character);
		this.gameManagerScript.StartGame();
	}
	
	// triggered when player reaches end zone and goes to main menu; the menu soundtrack should start playing
	public void GameToStartScreen()
	{
		this.gameManagerScript.PlayButtonClip();
		this.gameManagerScript.LoadStartScreen();
	}
	
	// toggles sound on and off
	public void ToggleVolume()
	{
		this.gameManagerScript.ToggleVolume();
		TextMeshProUGUI textComponent = GameObject.Find("SoundButton").GetComponentInChildren<TextMeshProUGUI>();
		if(textComponent.text == "Sound ON")
		{
			textComponent.text = "Sound OFF";
		}
		else
		{
			textComponent.text = "Sound ON";
		}
	}
	
	// toggles save points on and off
	public void ToggleSavePoints()
	{
		this.gameManagerScript.ToggleSavePoints();
		TextMeshProUGUI textComponent = GameObject.Find("SavePointButton").GetComponentInChildren<TextMeshProUGUI>();
		if(textComponent.text == "Save Points ON")
		{
			textComponent.text = "Save Points OFF";
		}
		else
		{
			textComponent.text = "Save Points ON";
		}
	}
}
