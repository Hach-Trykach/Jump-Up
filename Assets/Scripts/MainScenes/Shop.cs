using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

	public GameObject detectClicks, shopCubes;

	void OnEnable() {
		if(shopCubes != null)
		{
			detectClicks.GetComponent<BoxCollider> ().enabled = false;
			shopCubes.SetActive(true);
		}
	}

	void OnDisable() {
		if(shopCubes != null)
		{
			detectClicks.GetComponent<BoxCollider> ().enabled = true;
			shopCubes.SetActive(false);
		}
	}
}
