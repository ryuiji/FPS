using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public GameObject rightCanvas;
	private bool isOn = true;

	public enum AllOptions {
		StartGame,
		Options,
		Controls,
		Credits,
		MainMenu
	}
	public AllOptions Option;

	public void OnMouseDown () {
		switch(Option){
			case AllOptions.StartGame:
				Debug.Log("StartGame");
				StartGame();
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

	void StartGame () {
		// Load Level
	}

	void ShowOptions () {
		rightCanvas.SetActive(isOn);
		isOn = !isOn;
	}

	void ShowControls () {

	}

	void ShowCredits () {

	}

	void ReturnTomenu () {

	}
}
