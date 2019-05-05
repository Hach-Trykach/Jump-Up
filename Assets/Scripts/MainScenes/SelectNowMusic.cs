using UnityEngine;

public class SelectNowMusic : MonoBehaviour {

	public GameObject whichMusic;

	void OnMouseUp() {
		PlayerPrefs.SetString ("Now Music", whichMusic.GetComponent<SelectMusics> ().nowMusic);
		print ("Cube: " + PlayerPrefs.GetString("Cube") + ", BGs: " + PlayerPrefs.GetInt("QuantityBGs") + ", Musics: " + PlayerPrefs.GetInt("Musics"));
	}
}