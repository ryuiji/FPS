using UnityEngine;
using System.Collections;

public class UseScript : MonoBehaviour {

    public RaycastHit hit;
    public float rayDis;

    void Start() {
    }

    void Update () {
        OpenDoor();
	}

    void OpenDoor() {
        if (Input.GetButtonDown("Use")){
            if (Physics.Raycast(transform.position, transform.forward, out hit, rayDis) && hit.transform.tag == ("Deur")) {
                hit.transform.GetComponent<Animator>().SetTrigger("InteractDoor");
            }
        }
    }
}
