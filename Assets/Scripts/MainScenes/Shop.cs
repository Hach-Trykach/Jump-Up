using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	public GameObject detectClicks, shopCubes;

	void OnEnable() {
		detectClicks.GetComponent<BoxCollider> ().enabled = false;
		shopCubes.SetActive(true);
	}

	void OnDisable() {
		detectClicks.GetComponent<BoxCollider> ().enabled = true;
		shopCubes.SetActive(false);
	}
}
