using UnityEngine;

public class Harder : MonoBehaviour {

	public GameObject detectClicks;

	private bool easy;

	void Update () {
		if (CubeJump.count_blocks > 0) {
			if (CubeJump.count_blocks % 5 == 0 && !easy) {
				print ("Hard");
				Camera.main.GetComponent<Animation> ().Play ("HardGameCamera");
				detectClicks.transform.position = new Vector3 (8.05f, 0.82f, -9f);
				detectClicks.transform.eulerAngles = new Vector3 (7.10f, 317.9f, 0f);

				easy = true;
			} else if ((CubeJump.count_blocks % 5) - 1 == 0 && easy) {
				print ("Easy");
				Camera.main.GetComponent<Animation> ().Play ("EasyGameCamera");
				detectClicks.transform.position = new Vector3 (0f, 0f, -7f);
				detectClicks.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
				easy = false;
			}		
		}
	}
}