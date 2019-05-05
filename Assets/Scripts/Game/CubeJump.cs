using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;
//using StartApp;

public class CubeJump : MonoBehaviour {

	public GameObject mainCube, buttons, loseBackground;
    public static bool jump = false, nextBlock = false, moveBlocks = false, lose = false, adsLose = false;
	private bool animate = false;
	private float scratch_speed = 0.5f, startTime, yPosCube;
	public static int count_blocks, adsCount;
	public bool vnizu = false;

	void Awake() {
		jump = false;
		nextBlock = false;
        moveBlocks = false;
        lose = false;
        adsLose = false;
        //moveBlocks = false;
    }

	void Start() {
		StartCoroutine (CanJump ());

		//StartApp Ads
		//#if UNITY_ANDROID
		//StartAppWrapper.init();
		//StartAppWrapper.loadAd();
		//#endif

		//UNITY ADS
		 
		if (Advertisement.isSupported) {
			Advertisement.Initialize ("1466929", true);
		} else {
			Debug.Log ("Device if not supported");
		}
	}

	void FixedUpdate() {
		if (animate && mainCube.transform.localScale.y > 0.4f && !vnizu) {
			PressCube (-scratch_speed);
			if (mainCube.transform.localScale.y <= 0.4f) {
				vnizu = true;
			}
		} else if (animate && vnizu) {
			PressCube (scratch_speed);
			if (mainCube.transform.localScale.y >= 1f) {
				vnizu = false;
			}
		}
		if (!animate && mainCube != null) {
			if (mainCube.transform.localScale.y < 1f) {
				PressCube (scratch_speed * 4f);
			} else if (mainCube.transform.localScale.y != 1f) {
				mainCube.transform.localScale = new Vector3 (1f, 1f, 1f);
			}
		}
		if (mainCube.transform.position.y < -10f && mainCube.activeSelf) {
			mainCube.SetActive (false);
			print ("Player Lose & Destroy Cube");
			lose = true;
		}
		if (lose && !adsLose) {
			PlayerLose ();
		}
	}

	void PlayerLose () {
		adsCount++;
		if(Advertisement.IsReady() && adsCount % 7 == 0) {
			Advertisement.Show();
		}

		//if (adsCount % 7 == 0) {

			/*StartApp Ads
			* #if UNITY_ANDROID
			* StartAppWrapper.showSplash ();
			* print ("StartApp Ad is playing");
			* #endif
			* 
			* //#if UNITY_ANDROID
			* //StartAppWrapper.init();
			* //StartAppWrapper.loadAd();
			* //#endif
			* 
			* //#if UNITY_ANDROID
			* //StartAppWrapper.showAd();
			* //StartAppWrapper.loadAd();
			* //#endif
			*/
		//}

		adsLose = true;
		GetComponent<AudioSource> ().Play ();
		Camera.main.GetComponent<AudioSource> ().enabled = false;
		if (!loseBackground.activeSelf) {
            loseBackground.SetActive (true);
		}
	}

	void OnMouseDown() {
		if (!moveBlocks) {
			if (nextBlock && mainCube.GetComponent<Rigidbody> ()) {
				yPosCube = mainCube.transform.localPosition.y;
				animate = true;
				startTime = Time.time;
			}
		}
	}

	void OnMouseUp () {
		if (nextBlock && mainCube.GetComponent<Rigidbody> () && animate) {
			animate = false;
			jump = true;

			float force;
			force = 180f / mainCube.transform.localScale.y;//force = 125f

			if (gameObject.name == "Block" || gameObject.name == "FirstBlock") {
				if (gameObject.transform.position.y < -3) {
					Destroy (mainCube);
				}
			}

			mainCube.GetComponent<Rigidbody> ().AddForce (mainCube.transform.up * force * 4f);
			mainCube.GetComponent<Rigidbody> ().AddForce (mainCube.transform.right * force * 0.8f);
			Physics.gravity = new Vector3 (0, -55f, 0);

			nextBlock = false;
			StartCoroutine (checkCubePos ());
		}
	}

	void PressCube (float force) {
		mainCube.transform.localPosition += new Vector3 (0f, force * Time.deltaTime, 0f);
		mainCube.transform.localScale += new Vector3 (0.005f * -force, force * Time.deltaTime, 0f);
		mainCube.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
	}

	IEnumerator checkCubePos () {
			//yield return new WaitForSeconds (1f);
		if (yPosCube == mainCube.transform.position.y) {
			print ("Player Lose (Недопрыгнул)");
			lose = true;
		} else {
			while (!mainCube.GetComponent<Rigidbody> ().IsSleeping ()) {
				yield return new WaitForSeconds (0.05f);
				if (!mainCube.activeSelf) { //== null
					break;
				}
			}
			if (!lose) {
				//yield return new WaitForSeconds (0.5f);
				nextBlock = true;
				count_blocks++;
				print ("Next block");
				mainCube.transform.localPosition = new Vector3 (mainCube.transform.localPosition.x, mainCube.transform.localPosition.y, 0f);
				mainCube.transform.eulerAngles = new Vector3 (0f, 0f, 0f);
			}
		}
	}

	IEnumerator CanJump() {
		while (!mainCube.GetComponent<Rigidbody> ()) {
			yield return new WaitForSeconds (0.05f);
		}
		yield return new WaitForSeconds (1.5f);
		nextBlock = true;
	}
}