using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour {

	void Update () {
		GetComponent<CanvasGroup>().alpha += 1 * Time.deltaTime;
	}
}
