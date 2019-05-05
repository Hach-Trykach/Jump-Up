using UnityEngine;
using System.Collections;

public class SelectBG : MonoBehaviour {

	public GameObject selectBG, buyBG;
	public GameObject BG1, BG2, BG3, BG4, BG5, BG6;
	[HideInInspector]
	public string nowBG;

	void Start() {
		if (PlayerPrefs.GetString ("BG0") != "Open") {
			PlayerPrefs.SetString ("BG0", "Open");
			selectBG.SetActive (true);
			buyBG.SetActive (false);
		}

		PlayerPrefs.SetInt ("maxRangeBGs", 3);

		if (PlayerPrefs.GetInt ("QuantityBGs") >= 1) {
			BG2.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeBGs", 6);
		}

		if (PlayerPrefs.GetInt ("QuantityBGs") >= 2) {
			BG3.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeBGs", 9);
		}

		if (PlayerPrefs.GetInt ("QuantityBGs") >= 3) {
			BG4.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeBGs", 12);
		}

		if (PlayerPrefs.GetInt ("QuantityBGs") >= 4) {
			BG5.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeBGs", 15);
		}

		if (PlayerPrefs.GetInt ("QuantityBGs") >= 5) {
			BG6.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeBGs", 18);
		}
	}

	void OnTriggerEnter(Collider other) {
		GetComponent<AudioSource> ().Play ();
		nowBG = other.gameObject.name;
		if (other.transform.localScale.x <= 2.5f) {
			other.transform.localScale += new Vector3 (1f, 1f, 0f);
		}
		if (PlayerPrefs.GetString (other.gameObject.name) == "Open") {
			selectBG.SetActive (true);
			buyBG.SetActive (false);
		} else {
			selectBG.SetActive (false);
			buyBG.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		other.transform.localScale -= new Vector3 (1f, 1f, 0f);
	}
}