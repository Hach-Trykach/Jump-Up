using UnityEngine;

public class SelectNowCube : MonoBehaviour {

	public GameObject whichCube, mainCube;

	void OnMouseUp() {
		mainCube.GetComponent<MeshRenderer> ().material = GameObject.Find (whichCube.GetComponent<SelectCube> ().nowCube).GetComponent<MeshRenderer> ().material;
		PlayerPrefs.SetString ("Now Cube", whichCube.GetComponent<SelectCube> ().nowCube);
	}
}