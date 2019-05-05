using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour {

	public Vector3 starPos, starRotate;
	public float movementSpeed, rotate1, rotate2, rotate3;

	void Start () {
		movementSpeed = Random.Range (0.05f, 1f);
		rotate1 = Random.Range (0.005f, 0.5f);
		rotate2 = Random.Range (0.005f, 0.5f);
		rotate3 = Random.Range (0.005f, 0.5f);
		if (transform.localPosition.x < 0) {
			starPos = new Vector3 (5.1f, Random.Range (6f, -6f), transform.position.z);
		}
		if (transform.localPosition.x > 0) {
			starPos = new Vector3 (-5.1f, Random.Range (6f, -6f), transform.position.z);
		}
	}

	void Update () {
		transform.position = Vector3.MoveTowards (transform.position, starPos, Time.deltaTime * movementSpeed);
		transform.Rotate (new Vector3(rotate1,rotate2,rotate3));
		if (transform.position.x >= 5 || transform.position.x <= -5) {
			Start ();
		}
	}
}