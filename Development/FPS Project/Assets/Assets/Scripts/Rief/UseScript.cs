using UnityEngine;
using System.Collections;

public class UseScript : MonoBehaviour {

    public RaycastHit hit;
    private float rayDis = 10f;


	void Start () {

	}
    void Update() {
        ButtonInput();
    }
    void CanInteract(RaycastHit hit) {
        switch (hit.transform.GetComponent<Interactable>().interact) {
            case Interactable.Interact.Door:
            hit.transform.GetComponent<Door>();
                break;
            case Interactable.Interact.Inspectable:
                print("Inspectable");
                break;
            case Interactable.Interact.Gun:
                print("Gun");
                break;
            case Interactable.Interact.NPC:
                print("NPS");
                break;
        }
    }
    void ButtonInput() {
        if (Input.GetButtonDown("Use")) {
            if(Physics.Raycast(transform.position,transform.forward,out hit, rayDis)) {
                CanInteract(hit);
            }
        }
    }
	


}
