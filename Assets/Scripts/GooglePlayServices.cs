using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using System.Collections;

public class GooglePlayServices : MonoBehaviour
{

    public int count, doubleCancel;
    public GameObject closeButton;

    //public int FirstTimeGooglePlayServices, Current_Time, raznica;

    void Start()
    {
        //System.DateTime epochStart = new System.DateTime (1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        //Current_Time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds + 10810;

        //raznica = Current_Time - PlayerPrefs.GetInt ("FirstTimeGooglePlayServices");

        //if (raznica >= 43200) {
        //System.DateTime epochStart2 = new System.DateTime (1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);
        //FirstTimeGooglePlayServices = (int)(System.DateTime.UtcNow - epochStart2).TotalSeconds + 10810;
        //PlayerPrefs.SetInt ("FirstTimeGooglePlayServices", FirstTimeGooglePlayServices);
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        Connect();
        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        //PlayerPrefs.DeleteKey ("Top");
        //PlayerPrefs.DeleteKey ("Diamonds");
        //gps.text = "S: " + PlayerPrefs.GetInt("Top");
        //gpd.text = "D: " + PlayerPrefs.GetInt("maxDiamonds");
        //}
    }

    public void Connect()
    {
        Debug.Log("Connect to Google Play Services...");
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
        Social.localUser.Authenticate((bool success) => {
            if (success)
            {
                Debug.Log("Connect to Google Play Services: Success");
                Social.ReportScore(PlayerPrefs.GetInt("Top"), "CgkI9dLv-YcUEAIQAg", (bool successs) => { });
                //Social.ReportScore(PlayerPrefs.GetInt("maxDiamonds"), "CgkI9dLv-YcUEAIQBQ", (bool successs) => { });
            }
            else
            {
                count++;
                Debug.Log("Connect to Google Play Services: Failed");
                if (count < 5) Connect();
            }
        });
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                doubleCancel++;
                StartCoroutine (closeApp());
            }
        }
    }

    IEnumerator closeApp ()
    {
        closeButton.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        if (doubleCancel > 1) Application.Quit();
        else
            doubleCancel = 0;
            closeButton.SetActive(false);
    }
}
//Конфигурация и инициализация Google Play Services
/*
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

// Рекомендовано для откладки:
PlayGamesPlatform.DebugLogEnabled = true;
// Активировать Google Play Games Platform
PlayGamesPlatform.Activate();
////*
//Логин игрока

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
	...
	// Аутентификация игрока:
	Social.localUser.Authenticate((bool success) => {
		// Удачно или нет?
	});
////*
//Разблокирование достижения

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
	...
	// Разблокировать достижение (ID "Cfjewijawiu_QA")
	Social.ReportProgress("Cfjewijawiu_QA", 100.0f, (bool success) => {
		// Удачно или нет?
	});
////*
//Результат в таблицу

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
	...
	// Опубликовать счёт 12345 в таблицу ID "Cfji293fjsie_QA")
	Social.ReportScore(12345, "Cfji293fjsie_QA", (bool success) => {
		// Удачно или нет?
	});
////*
//Отображение списка достижений

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
	...
	// Показать список достижений.
	Social.ShowAchievementsUI();
////*
//Отображение таблицы

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
	...
	// Отображение таблицы.
	Social.ShowLeaderboardUI();
////*
//Выход из GPS

using GooglePlayGames;
using UnityEngine.SocialPlatforms;
	...
	// Выйти
	PlayGamesPlatform.Instance.SignOut();
////*/
