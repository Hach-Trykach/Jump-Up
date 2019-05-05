using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class CollectDiamonds : MonoBehaviour {

	public AudioClip collectDiamond;
	public Text diamonds;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Diamond") {
			other.GetComponent<AudioSource> ().clip = collectDiamond;
            if (PlayerPrefs.GetString("Sound") == "on")
            {
                other.GetComponent<AudioSource>().Play();
            }
            other.GetComponent<SpriteRenderer>().enabled = false;
            Destroy (other.gameObject, 0.3f);
			PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") + 1);
			//PlayerPrefs.SetInt ("maxDiamonds", PlayerPrefs.GetInt ("maxDiamonds") + 1);
			diamonds.text = PlayerPrefs.GetInt ("Diamonds").ToString ();
			Social.ReportProgress ("CgkI9dLv-YcUEAIQAQ", 100.0f, (bool success) => {
			});
		}
	}
}