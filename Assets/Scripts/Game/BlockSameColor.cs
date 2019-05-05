using UnityEngine;

public class BlockSameColor : MonoBehaviour {

	public AudioClip cubeDrop;

	void OnCollisionEnter(Collision other) {
		GetComponent<AudioSource> ().clip = cubeDrop;
		GetComponent<AudioSource> ().Play ();
		if (other.gameObject.tag == "Cube" || other.gameObject.tag == "FirstCube") {
			if (PlayerPrefs.GetInt ("QuantityCubes") < 1) {
				other.gameObject.GetComponent<MeshRenderer> ().material.color = GetComponent<RandColor> ().colors [Random.Range (0, PlayerPrefs.GetInt ("QuantityCubes") + 1)];
			} else {
				other.gameObject.GetComponent<MeshRenderer> ().material.color = GetComponent<RandColor> ().colors [Random.Range (1, PlayerPrefs.GetInt ("QuantityCubes") + 1)];
			}
        }
	}
}