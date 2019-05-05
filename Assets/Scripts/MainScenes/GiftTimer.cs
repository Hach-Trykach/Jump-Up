using UnityEngine;
using UnityEngine.UI;

public class GiftTimer : MonoBehaviour
{
    public static bool giftReceived, giftIsReady;
    public static int currentTime, timerScore, fourHour = 14400;//14400 если 4 часа
    public int hour, min, sec;
    public Text giftTimer;
    public GameObject giftTimerObj;

	void Start()
	{
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        currentTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds; // текущее время

        if (!PlayerPrefs.HasKey("rightTime"))
        {
            giftIsReady = true;
            PlayerPrefs.SetInt("rightTime", currentTime);
		}
		if (timerScore == 0 && giftIsReady)
        {
            giftTimerObj.SetActive(false);
            GetComponent<Animation>().Play("Gift");
        }
    }

    void Update()
    {
        checkTime();
        if (timerScore >= 0)
        {
            hour = (timerScore / 3600) - (timerScore / 86400) * 24;
            min = timerScore / 60 % 60;
            sec = timerScore % 60;
            if (min < 10 && sec >= 10)
            {
                giftTimer.text = ("0" + hour.ToString() + ":0" + min.ToString() + ":" + sec.ToString() + Strings.toGiftText);
            }
            else if (min >= 10 && sec < 10)
            {
                giftTimer.text = ("0" + hour.ToString() + ":" + min.ToString() + ":0" + sec.ToString() + Strings.toGiftText);
            }
            else if (min < 10 && sec < 10)
            {
                giftTimer.text = ("0" + hour.ToString() + ":0" + min.ToString() + ":0" + sec.ToString() + Strings.toGiftText);
            }
            else
            {
                giftTimer.text = ("0" + hour.ToString() + ":" + min.ToString() + ":" + sec.ToString() + Strings.toGiftText);
            }
        }
        else if (timerScore < 0)
        {
            giftTimerObj.SetActive(false);
            GetComponent<Animation>().Play("Gift");
            giftIsReady = true;
            Buttons.clickGift = true;
            timerScore = 0;
        }
    }

    public static void checkTime()
    {
        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        currentTime = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds; // текущее время

        if (!giftIsReady)
        {
            timerScore = PlayerPrefs.GetInt("rightTime") - currentTime;
        }
    }
}