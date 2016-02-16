using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	public GameObject leftCanvas;
	public GameObject rightCanvas;
	public GameObject optionMenu;
	public GameObject creditMenu;

	public GameObject[] allMenus;

	public bool showMenu;
	public bool showOptions;
	public bool showCredits;

	void GetInput () {
		if(Input.GetButtonDown("Cancel")){
			EnableDisableMenu();
			Debug.Log("De ESC knop is ingedrukt, de SwitchMenu wordt aangeroepen.");
		}
	}

	public void EnableDisableMenu () {
		leftCanvas.SetActive(showMenu);
		showMenu = !showMenu;
	}

	public void EnableDisableOptions () {
		rightCanvas.SetActive(showOptions);
		optionMenu.SetActive(showOptions);
		showOptions = !showOptions;
	}

	public void EnableDisableCredits () {
		creditMenu.SetActive(showCredits);
		showCredits = !showCredits;
	}

	public void Resume () {
		DisableAll();
	}

	public void Restart () {
		DisableAll();
		Application.LoadLevel(0);
	}

	void DisableAll () {
		for(int i = 0; i < allMenus.Length; i++){
			allMenus[i].SetActive(false);
			ResetBool();
		}
	}

	void ResetBool () {
		showMenu = true;
		showOptions = true;
		showCredits = true;
	}

	public void Update () {
		GetInput();
	}
}