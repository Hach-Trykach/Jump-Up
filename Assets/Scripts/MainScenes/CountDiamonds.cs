using UnityEngine;
using UnityEngine.UI;

public class CountDiamonds : MonoBehaviour {

	private Text countText;

	void Start () {
		countText = GetComponent<Text> ();
		countText.text = PlayerPrefs.GetInt ("Diamonds").ToString ();
	}
}