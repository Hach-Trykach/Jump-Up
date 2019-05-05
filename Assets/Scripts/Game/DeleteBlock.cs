using UnityEngine;
using System.Collections;

public class DeleteBlock : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Cube") {
			Destroy (other.gameObject);
		}
		if (other.tag == "FirstCube") {
			other.transform.position = new UnityEngine.Vector3 (-5, -8, 0);
		}
	}
}
