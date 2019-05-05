using UnityEngine;
using UnityEngine.UI;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class Score : MonoBehaviour {

	public Text top;
	private Text scoreText;
	private bool gameStart;

	void Start () {
		top.text = Strings.topText + PlayerPrefs.GetInt ("Top").ToString ();
		scoreText = GetComponent<Text> ();
		CubeJump.count_blocks = 0;
	}

	void Update() {
		if(scoreText.text == "0") {
			gameStart = true;
		}
		if(gameStart) {
			scoreText.text = CubeJump.count_blocks.ToString();
			if (PlayerPrefs.GetInt ("Top") == 1) {
				Social.ReportProgress ("CgkI9dLv-YcUEAIQAA", 100.0f, (bool success) => {
				});
			}
			if (PlayerPrefs.GetInt ("Top") < CubeJump.count_blocks) {
				PlayerPrefs.SetInt ("Top", CubeJump.count_blocks);
				top.text = Strings.topText + PlayerPrefs.GetInt ("Top").ToString ();
			}
		}
	}
}