using UnityEngine;
using System.Collections;

public class CloseInterface : MonoBehaviour {

	public GameObject inspectCanvas;

	public void DisableItself () {
		inspectCanvas.SetActive(false);
	}
}
