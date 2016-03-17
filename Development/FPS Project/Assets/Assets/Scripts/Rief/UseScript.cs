using UnityEngine;
using System.Collections;

public class UseScript : MonoBehaviour {
    public RaycastHit hit;
    private float rayDis = 4f;

	void Start () {
	
	}
	

	void Update () {
        OpenCloseDoor();
	}
    void OpenCloseDoor() {
        if (Input.GetButtonDown("Use")) {
            if(Physics.Raycast(transform.position,transform.forward, out hit, rayDis) && hit.transform.tag == ("Deur")) {
                hit.transform.GetComponent<Animator>().SetTrigger("DoorInteraction");
            }
        }
    }
}
