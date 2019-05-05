using UnityEngine;
using System.Collections;

public class MainMusicTheme : MonoBehaviour {

	public AudioClip[] Tracks;

	void Start () {
		Camera.main.GetComponent<AudioSource> ().clip = Tracks[Random.Range(0, PlayerPrefs.GetInt("Musics")+1)];
	}
}