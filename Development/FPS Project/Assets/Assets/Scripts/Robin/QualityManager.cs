using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QualityManager : MonoBehaviour {

	public void UpdateQualitySettings () {
		print("Test");
		QualitySettings.SetQualityLevel(GetComponent<Dropdown>().value);
	}


}
