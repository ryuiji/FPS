using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public CharacterController cc;
    private Vector3 movement;
    private float moveSpeed = 4f;
    private float rotateSpeed = 4f;
    private float jumpForce = 750f;
    private float gravity = 10f;
    public Vector3 tempRotation;
    public float curRot;

    void Start() {
        cc = GetComponent<CharacterController>();
    }

    void Update() {
        MouseMoveClamp();
        Jump();
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movement *= moveSpeed * Time.deltaTime;
        movement = transform.TransformDirection(movement);
        cc.Move(movement);
    }

    void MouseMoveClamp() {
        float vertical = rotateSpeed * -Input.GetAxis("Mouse Y");
        float horizontal = rotateSpeed * Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontal, 0);
        Camera.main.transform.Rotate(vertical, 0, 0);
        curRot += vertical;
        curRot = Mathf.Clamp(curRot, 0, 30); //aanpassen wanneer we de main character hebben. (1e naar boven, 2e naar onder)
        Camera.main.transform.localEulerAngles = new Vector3(curRot, Camera.main.transform.localEulerAngles.y, Camera.main.transform.localEulerAngles.z);
    }

    void Jump() {
        if (Input.GetButtonDown ("Jump") && cc.isGrounded) {
            movement.y = jumpForce * Time.deltaTime;
        }
        movement.y -= gravity * Time.deltaTime;
        cc.Move(movement * Time.deltaTime);
    }
}
