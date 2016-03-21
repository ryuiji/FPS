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
	public Transform tempPosition;
	private Vector3 oldPosition;
	private Quaternion oldRotation;

	public GameObject name;
	public GameObject weight;
	public GameObject tip;
	public GameObject description;
	public float rotateSpeed;

	void Update () {
		CheckBool();
		GetInput();
	}

	void CheckBool () {
		if(inspecting == false){
			ShootRay();
		}else{
			InspectObject(hit);
		}
	}

	void GetInput () {
		if(inspecting == true) {
			if(Input.GetButtonDown("Cancel")) {
				DisableInspecting(hit);
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
				SavePosition(hit);
				inspecting = true;
				InspectObject(hit);
				inspectText.SetActive(false);
			}
		}
	}

	void SavePosition (RaycastHit hit) {
		oldPosition = hit.transform.position;
		oldRotation = hit.transform.rotation;

	}

	void InspectObject (RaycastHit hit) {
		DisableMovement();
		GetInfo();
		inspectCanvas.SetActive(true);
		hit.transform.gameObject.layer = 8;
		hit.transform.position = tempPosition.position;
		if(Input.GetButton("Fire1")) {
			hit.transform.Rotate(-Input.GetAxis("Mouse Y") * rotateSpeed * Time.deltaTime, -Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime,0, Space.World);
		}
	}

	void DisableInspecting (RaycastHit hit) {
		inspecting = false;
		EnableMovement();
		inspectCanvas.SetActive(false);
		hit.transform.gameObject.layer = 0;
		hit.transform.position = oldPosition;
		hit.transform.rotation = oldRotation;
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
