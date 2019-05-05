using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour {

	public Text diamondText;
	public GameObject whichCube, whichBG, whichMusic, selectButton, mainCube;
	public GameObject BG1, BG2, BG3, BG4, BG5, BG6;
	public GameObject M1, M2, M3, M4, M5, M6;

	void Start() {
		//PlayerPrefs.SetInt ("Diamonds", 40);
	}

	void OnMouseUp() {
		if (Camera.main.transform.position.x == 100) {
			if (PlayerPrefs.GetInt ("Diamonds") >= 20) {
				PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") - 20);
				PlayerPrefs.SetString (whichCube.GetComponent<SelectCube> ().nowCube, "Open");
				PlayerPrefs.SetInt("QuantityCubes", PlayerPrefs.GetInt ("QuantityCubes") + 1);
				mainCube.GetComponent<MeshRenderer> ().material = GameObject.Find (whichCube.GetComponent<SelectCube> ().nowCube).GetComponent<MeshRenderer> ().material;
				PlayerPrefs.SetString ("Now Cube", whichCube.GetComponent<SelectCube> ().nowCube);
				selectButton.SetActive (true);
				gameObject.SetActive (false);
                if (PlayerPrefs.GetString("Sound") == "on")
                {
                    GetComponentInParent<AudioSource>().Play();
                }
				if (PlayerPrefs.GetInt ("QuantityCubes") >= 7) {
					Social.ReportProgress ("CgkI9dLv-YcUEAIQBw", 100.0f, (bool success) => {
					});
				}
			}
		}

		if (Camera.main.transform.position.x == 200) {
			if (PlayerPrefs.GetInt ("Diamonds") >= 20) {
				PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") - 20);
				PlayerPrefs.SetInt ("QuantityBGs", PlayerPrefs.GetInt ("QuantityBGs") + 1);
				if (PlayerPrefs.GetInt ("maxRangeBGs") < 18) {
					PlayerPrefs.SetInt ("maxRangeBGs", PlayerPrefs.GetInt ("maxRangeBGs") + 3);
				}
				PlayerPrefs.SetString (whichBG.GetComponent<SelectBG> ().nowBG, "Open");
				Camera.main.GetComponent<Skybox> ().material = GameObject.Find (whichBG.GetComponent<SelectBG> ().nowBG).GetComponent<MeshRenderer> ().material;
				PlayerPrefs.SetString ("Now BG", whichBG.GetComponent<SelectBG> ().nowBG);
				selectButton.SetActive (true);
				gameObject.SetActive (false);
                if (PlayerPrefs.GetString("Sound") == "on")
                {
                    GetComponentInParent<AudioSource>().Play();
                }
				if (PlayerPrefs.GetInt ("QuantityBGs") >= 6) {
					Social.ReportProgress ("CgkI9dLv-YcUEAIQCA", 100.0f, (bool success) => {
					});
				}
				if (PlayerPrefs.GetInt ("QuantityBGs") >= 1)
					BG2.SetActive (true);
				if (PlayerPrefs.GetInt ("QuantityBGs") >= 2)
					BG3.SetActive (true);
				if (PlayerPrefs.GetInt ("QuantityBGs") >= 3)
					BG4.SetActive (true);
				if (PlayerPrefs.GetInt ("QuantityBGs") >= 4)
					BG5.SetActive (true);
				if (PlayerPrefs.GetInt ("QuantityBGs") >= 5)
					BG6.SetActive (true);
			}
		}

		if (Camera.main.transform.position.x == 300) {
			if (PlayerPrefs.GetInt ("Diamonds") >= 20) {
				PlayerPrefs.SetInt ("Diamonds", PlayerPrefs.GetInt ("Diamonds") - 20);
				PlayerPrefs.SetInt ("Musics", PlayerPrefs.GetInt ("Musics") + 1);
				if (PlayerPrefs.GetInt ("maxRangeMusic") < 10) {
					PlayerPrefs.SetInt ("maxRangeMusic", PlayerPrefs.GetInt ("maxRangeMusic") + 2);
				}
				PlayerPrefs.SetString (whichMusic.GetComponent<SelectMusics> ().nowMusic, "Open");
				PlayerPrefs.SetString ("Now Music", whichMusic.GetComponent<SelectMusics> ().nowMusic);
				selectButton.SetActive (true);
				gameObject.SetActive (false);
                if (PlayerPrefs.GetString("Sound") == "on")
                {
                    GetComponentInParent<AudioSource>().Play();
                }
				if (PlayerPrefs.GetInt ("Musics") >= 5) {
					Social.ReportProgress ("CgkI9dLv-YcUEAIQCQ", 100.0f, (bool success) => {
					});
				}
				if (PlayerPrefs.GetInt ("Musics") >= 1)
					M3.SetActive (true);
				if (PlayerPrefs.GetInt ("Musics") >= 2)
					M4.SetActive (true);
				if (PlayerPrefs.GetInt ("Musics") >= 3)
					M5.SetActive (true);
				if (PlayerPrefs.GetInt ("Musics") >= 4)
					M6.SetActive (true);
			}
		}
		diamondText.text = PlayerPrefs.GetInt ("Diamonds").ToString ();
	}
}