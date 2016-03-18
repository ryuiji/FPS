using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Inspect : MonoBehaviour {
	public float rayDistance;
	private GameObject inspectObject;
	public GameObject inspectText;
	public GameObject inspectCanvas;
	private bool inspecting;
	public RaycastHit hit;

	public GameObject name;
	public GameObject weight;
	public GameObject tip;
	public GameObject description;
	
	void Update () {
		CheckBool();
		GetInput();
	}

	void CheckBool () {
		if(inspecting == false){
			ShootRay();
		}else{
			InspectObject();
		}
	}

	void GetInput () {
		if(inspecting == true) {
			if(Input.GetButtonDown("Cancel")) {
				DisableInspecting();
			}
		}
	}

	void ShootRay () {
		Debug.DrawRay(transform.position, transform.forward, Color.red);
		if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance)) {
			CheckTag(hit);
		}else{
			inspectText.SetActive(false);
		}
	}

	void CheckTag (RaycastHit hit) {
		if(hit.transform.tag == "Inspect") {
			inspectText.SetActive(true);
			if(Input.GetButtonDown("Use")) {
				inspecting = true;
				InspectObject();
				inspectText.SetActive(false);
			}
		}
	}

	void InspectObject () {
		DisableMovement();
		GetInfo();
		inspectCanvas.SetActive(true);
	}

	void DisableInspecting () {
		inspecting = false;
		EnableMovement();
		inspectCanvas.SetActive(false);
	}

	void GetInfo () {
		ItemStats itemStats = hit.transform.gameObject.GetComponent<ItemStats>();
		name.GetComponent<Text>().text = itemStats.name;
		weight.GetComponent<Text>().text = itemStats.weight.ToString();
		tip.GetComponent<Text>().text = itemStats.tip;
		description.GetComponent<Text>().text = itemStats.description;
	}

	void DisableMovement () {
		//
	}

	void EnableMovement () {
		//
	}
}
