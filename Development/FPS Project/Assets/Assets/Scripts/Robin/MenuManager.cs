using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public GameObject optionMenu;
	private bool isOn = true;
	private bool isFading;

	public enum AllOptions {
		StartGame,
		Options,
		Controls,
		Credits,
		MainMenu,
	}
	public AllOptions Option;

	public void OnMouseDown () {
		switch(Option){
			case AllOptions.StartGame:
				Debug.Log("StartGame");
				Resume();
				break;
			case AllOptions.Options:
				Debug.Log("Options");
				ShowOptions();
				break;
			case AllOptions.Controls:
				Debug.Log("Controls");
				ShowControls();
				break;
			case AllOptions.Credits:
				Debug.Log("Credits");
				ShowCredits();
				break;
			case AllOptions.MainMenu:
				Debug.Log("Main Menu");
				ReturnTomenu();
				break;
		}
	}

	void Update () {
		GetInput();
		print(isOn);
	}

	void GetInput () {
		if(Input.GetButtonDown("Cancel")){
			leftCanvas.SetActive(isOn);
			rightCanvas.SetActive(isOn);
			isOn = !isOn;
		}
	}

	void Resume () {
		isOn = true;
		leftCanvas.SetActive(false);
		optionMenu.SetActive(false);
	}

	void ShowOptions () {
		optionMenu.SetActive(isOn);
		isOn = !isOn;
	}

	void ShowControls () {
		
	}

	void ShowCredits () {

	}

	void ReturnTomenu () {

	}

	public void Back () {
		optionMenu.SetActive(false);
	}
}
