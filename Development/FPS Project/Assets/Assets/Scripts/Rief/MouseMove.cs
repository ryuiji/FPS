using UnityEngine;
using System.Collections;

public class MouseMove : MonoBehaviour {


    public float horizontalSpeed;
    public float verticalSpeed;


    void Update() {

        float horizontal = horizontalSpeed * Input.GetAxis("Mouse X");
        float vertical = verticalSpeed * -Input.GetAxis("Mouse Y");
        transform.Rotate(vertical, horizontal, 0);
    }
}
