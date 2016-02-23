using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    public float rotationSpeed;


    private bool mayMove;
    public Vector3 moveDirection;

    void Start() {
        mayMove = true;
    }
    void FixedUpdate() {
        moveDirection = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, 1)) {
            mayMove = false;
        }
        if(mayMove == true) {
        }
    }
}
