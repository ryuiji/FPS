using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public bool showMenu = true;

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
			ShowMenu();
		}
	}

	public void OnMouseDown () {
		switch(Option){
			case AllOptions.StartGame:
				Debug.Log("StartGame");
				HideMenu();
				break;
			case AllOptions.Options:
				Debug.Log("Options");
				//
				break;	
			case AllOptions.Controls:
				Debug.Log("Controls");
				//
				break;
			case AllOptions.Credits:
				Debug.Log("Credits");
				//
				break;
			case AllOptions.MainMenu:
				Debug.Log("Main Menu");
				//
				break;
		}
	}

	void ShowMenu () {
		leftCanvas.SetActive(true);
		rightCanvas.SetActive(true);
	}

	void HideMenu () {
		leftCanvas.SetActive(false);
		rightCanvas.SetActive(false);
	}

	void Update () {
		GetInput();
	}
}
