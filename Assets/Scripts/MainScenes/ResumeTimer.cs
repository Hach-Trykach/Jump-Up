using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeTimer : MonoBehaviour {

    public static float timeLeft;
    public Text timer;
    
	void Start () {
        timeLeft = 5;
    }
	
	void Update () {
        if (timeLeft > 0) {
            timer.text = timeLeft.ToString("0.");
            timeLeft -= Time.deltaTime;
        }
        else {
            SceneManager.LoadScene("Main");
        }
    }
}