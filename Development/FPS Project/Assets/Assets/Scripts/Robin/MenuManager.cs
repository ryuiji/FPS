using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public GameObject optionMenu;
	public bool showMenu = true;
	public bool showOptions = true;

	public enum AllOptions {
		Restart,
		Options,
		Credits,
		MainMenu,
		Back,
	}
	public AllOptions Option;

	void GetInput () {
		if(Input.GetButtonDown("Cancel")){
			SwitchMenu();
			Debug.Log("De ESC knop is ingedrukt, de SwitchMenu wordt aangeroepen.");
		}
	}

	public void OnMouseDown () {
		switch(Option){
			case AllOptions.Restart:
				Debug.Log("De knop restart is ingedrukt.");
				LoadLevel();
				break;
			case AllOptions.Options:
				Debug.Log("De knop options is ingedrukt.");
				SwitchOptions();
				break;
			case AllOptions.Credits:
				Debug.Log("De knop credits is ingedrukt.");
				//
				break;
			case AllOptions.MainMenu:
				Debug.Log("De knop return is ingedrukt.");
				//
				break;
			case AllOptions.Back:
				Debug.Log("Sluit menu");
				optionMenu.SetActive(false);
				break;
		}
	}

	public void Switch () {
		showMenu = !showMenu;
		Debug.Log("De function Switch() wordt nu uitgevoerd.");
		Debug.Log(showMenu);
	}

	public void SwitchMenu () {
		showOptions = !showOptions;
		leftCanvas.SetActive(showMenu);
		rightCanvas.SetActive(showMenu);
		Debug.Log("SwitchMenu wordt uitgevoerd. Leftcanvas + Rightcanvas gaat aan/uit.");
		Switch();
	}

	public void SwitchOptions () {
		showOptions = !showOptions;
		optionMenu.SetActive(showOptions);
		Debug.Log("SwitchOptions wordt uitgevoerd. OptionMenu gaat aan/uit.");
	}

	public void Update () {
		GetInput();
	}

	public void LoadLevel () {
		Application.LoadLevel(0);
		Debug.Log("Het level wordt volledige herladen.");
	}
}