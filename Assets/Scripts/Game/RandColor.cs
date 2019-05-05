using UnityEngine;

public class RandColor : MonoBehaviour {
	
	public Color[] colors;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		//PlayerPrefs.SetInt ("Diamonds", 2879);
		if (gameObject.tag != "Player") {
            if (PlayerPrefs.GetInt("QuantityCubes") < 1) {
                GetComponent<MeshRenderer>().material.color = colors[Random.Range(0, PlayerPrefs.GetInt("QuantityCubes") + 1)];
            } else {
                GetComponent<MeshRenderer>().material.color = colors[Random.Range(1, PlayerPrefs.GetInt("QuantityCubes") + 1)];
            }
		}
	}
}