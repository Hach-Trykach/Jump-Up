using UnityEngine;

public class ScrollObjects : MonoBehaviour {

	public float speed = 10f, checkpos = 0f;
	private RectTransform rect;

	void Start() {
		rect = GetComponent<RectTransform> ();
	}

	void Update () {
		if (rect.offsetMin.y != checkpos) {
			rect.offsetMin += new Vector2 (rect.offsetMin.x, speed);
			rect.offsetMax += new Vector2 (rect.offsetMax.x, speed);
		}
	}
}
