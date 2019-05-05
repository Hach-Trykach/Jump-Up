using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DetectClicks : MonoBehaviour
{

    public GameObject buttons, gameCube, spawn_blocks, diamonds, sound, gift, giftTimerText;
    public Text playText, gameName, top_count, study, diamondsText;
    private bool clicked;

    void OnMouseDown()
    {
        if (GiftTimer.giftReceived) {	
			gameCube.SetActive (true);
			if (!clicked) {
				clicked = true;
				StartCoroutine (Spawn ());
				Camera.main.GetComponent<AudioSource> ().Play ();
				playText.gameObject.SetActive (false);
				study.gameObject.SetActive (true);
				gameName.text = "0";
                diamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
                top_count.gameObject.SetActive (true);
				diamonds.GetComponent<Animation> ().Play ("ScrollDiamonds");
				gift.SetActive (false);
				giftTimerText.SetActive (false);
				if (sound.activeSelf) {
					for (int i = 0; i < sound.transform.parent.transform.childCount; i++)
						sound.transform.parent.transform.GetChild (i).gameObject.SetActive (!sound.transform.parent.transform.GetChild (i).gameObject.activeSelf);
				}
				buttons.GetComponent<ScrollObjects> ().speed = -10f;
				buttons.GetComponent<ScrollObjects> ().checkpos = -200f;
			} else if (clicked && study.gameObject.activeSelf) {
				study.gameObject.SetActive (false);
			}
		}
    }

    IEnumerator Spawn()
    {
        spawn_blocks.GetComponent<SpawnBlocks>().enabled = true;
        gameCube.AddComponent<Rigidbody>();
        Rigidbody RB = gameCube.GetComponent<Rigidbody>();
        RB.drag = 0.5f;
        RB.angularDrag = 2f;
        yield return new WaitForSeconds(0.0001f);//(gameCube.GetComponent<Animation> ().clip.length - 2.5f);
    }
}