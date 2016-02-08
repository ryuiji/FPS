using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public GameObject rightCanvas;

	public enum AllOptions {
		StartGame,
		Options,
		Controls,
		Credits,
		MainMenu
	}
	public AllOptions Option;

	void Awake () {
		rightCanvas.SetActive(true);
	}
	
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

	}

	void ShowOptions () {

	}

	void ShowControls () {

	}

	void ShowCredits () {

	}

	void ReturnTomenu () {

	}
}
