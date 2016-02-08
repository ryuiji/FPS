using UnityEngine;
using System.Collections;

public class OpenMenu : MonoBehaviour {
	public GameObject MainMenu;
	private bool isOn;

	void Start () {
		isOn = true;
	}

	void Update () {
		GetInput();
	}

	void GetInput () {
		if(Input.GetButtonDown("Cancel")){
			MainMenu.SetActive(isOn);
			isOn = !isOn;
		}
	}
}
