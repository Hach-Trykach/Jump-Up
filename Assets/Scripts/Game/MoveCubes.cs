using UnityEngine;
using System.Collections;

public class MoveCubes : MonoBehaviour {

	private bool moved = false;
	private Vector3 target;

	void Start () {
		target = new UnityEngine.Vector3 (0f, 0f, 0f);
	}

	void Update () {
		if (CubeJump.nextBlock) {
			if (transform.position != target) {
				transform.position = UnityEngine.Vector3.MoveTowards (transform.position, target, Time.deltaTime * 10f);
			} else if (transform.position == target && moved) {
				target = new UnityEngine.Vector3 (transform.position.x - 2.72f, transform.position.y - 2.33f, transform.position.z);
				moved = false;
				CubeJump.jump = false;
				CubeJump.moveBlocks = true;
				StartCoroutine(MoveAllCubes());
			}
			if (CubeJump.jump) {
				moved = true;
			}
		}
	}
	IEnumerator MoveAllCubes() {
		yield return new WaitForSeconds (0.5f);
		CubeJump.moveBlocks = false;
	}
}