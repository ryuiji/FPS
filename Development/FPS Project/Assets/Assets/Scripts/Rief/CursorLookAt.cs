using UnityEngine;
using System.Collections;

public class CursorLookAt : MonoBehaviour {
    
	void Start () {
	
	}
	
	void Update () {
        transform.LookAt(Camera.main.transform.position);
    }
}
