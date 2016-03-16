using UnityEngine;
using System.Collections;

public class Inspect : MonoBehaviour {
	public float rayDistance;
	private GameObject inspectObject;
	private bool inspecting;
	private RaycastHit hit;
	
	void Update () {
		CheckBool();
	}

	void CheckBool () {
		if(inspecting == false){
			ShootRay();
		}else{
			InspectObject();
		}
	}

	void ShootRay () {
		Debug.DrawRay(transform.position, transform.forward, Color.red);
		if(Physics.Raycast(transform.position, transform.forward, out hit, rayDistance)){
			CheckTag(hit);
		}
	}

	void CheckTag (RaycastHit hit) {
		if(hit.transform.tag == "Inspect"){
			Debug.Log("Hit");
			if(Input.GetButtonDown("Use")){
				inspectObject = hit.transform.gameObject;
				inspecting = true;
			}
		}
	}

	void InspectObject() {

	}
}
