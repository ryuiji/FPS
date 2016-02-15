using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	public GameObject[] optionContent;
	public GameObject optionMenu; 
	private int currentMenu;

	public void Graphics () {
		TurnOff();
		currentMenu = 0;
		optionContent[currentMenu].SetActive(true);
	}

	public void Audio () {
		TurnOff();
		currentMenu = 1;
		optionContent[currentMenu].SetActive(true);
	}

	public void Controls () {
		TurnOff();
		currentMenu = 2;
		optionContent[currentMenu].SetActive(true);
	}

	public void TurnOff () {
		for(int i = 0; i < optionContent.Length; i++){
			optionContent[i].SetActive(false);
		}
	}
}
