using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public GameObject optionMenu;
	public bool isOn = true;
	private bool isFading;

	public enum AllOptions {
		StartGame,
		Options,
		Controls,
		Credits,
		MainMenu,
	}
	public AllOptions Option;

	void GetInput () {
		if(Input.GetButtonDown("Cancel")){
			leftCanvas.SetActive(isOn);
			rightCanvas.SetActive(isOn);
			isOn = !isOn;
			Debug.Log ("De functie GetInput wordt uitgevoerd.");
		}
	}

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
	/*
		
	*/

	void Resume () {
		isOn = true;
		leftCanvas.SetActive(!isOn);
		optionMenu.SetActive(!isOn);
		Debug.Log ("De functie Resume wordt uitgevoerd. Dit moet isOn op true zetten.");
	}

	void ShowOptions () {
		optionMenu.SetActive(isOn);
		isOn = !isOn;
		Debug.Log ("De functie ShowOptions wordt uitgevoerd.");
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
