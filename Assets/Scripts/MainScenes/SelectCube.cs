using UnityEngine;

public class SelectCube : MonoBehaviour {

	public GameObject selectCube, buyCube;
	[HideInInspector]
	public string nowCube;

	void Start() {
		if (PlayerPrefs.GetString ("Cube") != "Open") {
			PlayerPrefs.SetString ("Cube", "Open");
			selectCube.SetActive (true);
			buyCube.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider other) {
		GetComponent<AudioSource> ().Play ();
			nowCube = other.gameObject.name;
			if (other.transform.localScale.x <= 1f) {
				other.transform.localScale += new Vector3 (0.4f, 0.4f, 0.4f);
			}
		if (PlayerPrefs.GetString (other.gameObject.name) == "Open") {
			selectCube.SetActive (true);
			buyCube.SetActive (false);
		} else {
			selectCube.SetActive (false);
			buyCube.SetActive (true);
		}
	}

	void OnTriggerExit(Collider other) {
		other.transform.localScale -= new Vector3 (0.4f, 0.4f, 0.4f);
	}
}