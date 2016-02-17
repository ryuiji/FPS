using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

	public GameObject graphics;
	public GameObject audio;
	public GameObject controls;
	public GameObject[] allOptions;

	public GameObject graphicDropdown;

	public void ChangeQuality () {
		QualitySettings.SetQualityLevel(graphicDropdown.GetComponent<Dropdown>().value);
	}

	public void EnableDisableGraphics () {
		DisableAll();
		graphics.SetActive(true);
	}

	public void EnableDisableAudio () {
		DisableAll();
		audio.SetActive(true);
	}

	public void EnableDisableControls () {
		DisableAll();
		controls.SetActive(true);
	}

	void DisableAll () {
		for(int i = 0; i < allOptions.Length; i++){
			allOptions[i].SetActive(false);
		}
	}
}
