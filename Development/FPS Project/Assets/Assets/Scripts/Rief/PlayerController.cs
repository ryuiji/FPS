using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


    public float moveSpeed;
    public float straveSpeed;
    public CharacterController cc;

    void Start() {
        cc = GetComponent<CharacterController>();
    }
    void FixedUpdate() {

        Vector3 moveForward = Input.GetAxis("Vertical") * transform.TransformDirection(Vector3.forward) * moveSpeed;
        Vector3 moveSide = Input.GetAxis("Horizontal") * transform.TransformDirection(Vector3.right) * straveSpeed;
        cc.Move(moveForward * Time.deltaTime);
        cc.Move(moveSide * Time.deltaTime);
    }
}
