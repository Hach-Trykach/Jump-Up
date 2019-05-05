using UnityEngine;

public class SelectMusics : MonoBehaviour {

	public GameObject selectMusic, buyMusic;
	public GameObject M1, M2, M3, M4, M5, M6;
	public AudioClip track1, track2, track3, track4, track5, track6;
	[HideInInspector]
	public string nowMusic;

	void Start() {
		if (PlayerPrefs.GetString ("M1") != "Open") {
			PlayerPrefs.SetString ("M1", "Open");
			selectMusic.SetActive (true);
			buyMusic.SetActive (false);
		}

		PlayerPrefs.SetInt ("maxRangeMusic", 2);

		if (PlayerPrefs.GetInt ("Musics") >= 1) {
			M3.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeMusic", 4);
		}

		if (PlayerPrefs.GetInt ("Musics") >= 2) {
			M4.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeMusic", 6);
		}

		if (PlayerPrefs.GetInt ("Musics") >= 3) {
			M5.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeMusic", 8);
		}

		if (PlayerPrefs.GetInt ("Musics") >= 4) {
			M6.SetActive (true);
			PlayerPrefs.SetInt ("maxRangeMusic", 10);
		}
	}

	void OnTriggerEnter(Collider other) {
		GetComponent<AudioSource> ().Play ();
		nowMusic = other.gameObject.name;
		if (other.transform.localScale.x <= 0.25f) {
			other.transform.localScale += new Vector3 (0.1f, 0.1f, 0f);

		}
		if (PlayerPrefs.GetString (other.gameObject.name) == "Open") {
			selectMusic.SetActive (true);
			buyMusic.SetActive (false);
		} else {
			selectMusic.SetActive (false);
			buyMusic.SetActive (true);
		}
		if(other.gameObject.name == "M1")
			Camera.main.GetComponent<AudioSource> ().PlayOneShot(track1);
		if(other.gameObject.name == "M2")
			Camera.main.GetComponent<AudioSource> ().PlayOneShot(track2);
		if(other.gameObject.name == "M3")
			Camera.main.GetComponent<AudioSource> ().PlayOneShot(track3);
		if(other.gameObject.name == "M4")
			Camera.main.GetComponent<AudioSource> ().PlayOneShot(track4);
		if(other.gameObject.name == "M5")
			Camera.main.GetComponent<AudioSource> ().PlayOneShot(track5);
		if(other.gameObject.name == "M6")
			Camera.main.GetComponent<AudioSource> ().PlayOneShot(track6);
	}

	void OnTriggerExit(Collider other) {
		other.transform.localScale -= new Vector3 (0.1f, 0.1f, 0f);
		Camera.main.GetComponent<AudioSource> ().Stop();
	}
}