using UnityEngine;
using System.Collections;

public class RandBackground : MonoBehaviour {

	public Material[] materials;

	void Start() {
		if (PlayerPrefs.GetInt ("QuantityBGs") <= 0) {
			GetComponent<Skybox> ().material = materials [0];
		} else {
			GetComponent<Skybox> ().material = materials [Random.Range (1, PlayerPrefs.GetInt ("QuantityBGs")+1)];
		}
	}
}