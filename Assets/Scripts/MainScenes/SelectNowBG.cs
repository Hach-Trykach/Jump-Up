using UnityEngine;

public class SelectNowBG : MonoBehaviour {

	public GameObject whichBG;

	void OnMouseUp() {
		Camera.main.GetComponent<Skybox> ().material = GameObject.Find (whichBG.GetComponent<SelectBG> ().nowBG).GetComponent<MeshRenderer> ().material;
		PlayerPrefs.SetString ("Now BG", whichBG.GetComponent<SelectBG> ().nowBG);
	}
}