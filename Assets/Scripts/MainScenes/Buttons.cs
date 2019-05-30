using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using GooglePlayGames;
using System.Collections;

public class Buttons : MonoBehaviour
{

    public static bool clickGift;
    public int ADS, randomCount, randomDiamonds;
    public Text diamondsText;
    public AudioClip collectDiamond;
    public Sprite soundOn, soundOff, musicOn, musicOff;
    public GameObject buttons, shopCubes, shopBGs, shopMusics, gameName, tapToPlay, allCubes, shopBackground, loseBackground, mainCube, detectClicks, whichCube, whichBg, whichMusic, 
        shopBtn, achivBtn, leaderBtn, settingsBtn, musicBtn, soundBtn, vkBtn, backBtn, selectBtn, buyBtn, restartBtn, sCubesBtn, sBgBtn, sMusicBtn, siteBtn, WatchAdForDiamondBtn, 
        continueBtn, adsBackground, withAdsBtn, withoutAdsBtn, privacyBtn, gift, giftImage, giftTimerText, diamonds;

    void Start()
    {
        clickGift = true;
        GiftTimer.giftReceived = true;
        if (Advertisement.isSupported) Advertisement.Initialize("1466929", true);
        else Debug.Log("Device if not supported");
        if (gameObject.name == "Settings")
        {
            if (PlayerPrefs.GetString("Music") == "off")
            {
                transform.GetChild(0).gameObject.GetComponent<Image>().sprite = musicOff;
                Camera.main.GetComponent<AudioSource>().mute = true;
            }
            if (PlayerPrefs.GetString("Sound") == "off")
            {
                transform.GetChild(1).gameObject.GetComponent<Image>().sprite = soundOff;
                mainCube.GetComponent<AudioSource>().mute = true;
                detectClicks.GetComponent<AudioSource>().mute = true;
                whichCube.GetComponent<AudioSource>().mute = true;
                whichBg.GetComponent<AudioSource>().mute = true;
                whichMusic.GetComponent<AudioSource>().mute = true;
                shopBtn.GetComponent<AudioSource>().mute = true;
                achivBtn.GetComponent<AudioSource>().mute = true;
                leaderBtn.GetComponent<AudioSource>().mute = true;
                settingsBtn.GetComponent<AudioSource>().mute = true;
                musicBtn.GetComponent<AudioSource>().mute = true;
                soundBtn.GetComponent<AudioSource>().mute = true;
                vkBtn.GetComponent<AudioSource>().mute = true;
                backBtn.GetComponent<AudioSource>().mute = true;
                selectBtn.GetComponent<AudioSource>().mute = true;
                buyBtn.GetComponent<AudioSource>().mute = true;
                restartBtn.GetComponent<AudioSource>().mute = true;
                siteBtn.GetComponent<AudioSource>().mute = true;
                WatchAdForDiamondBtn.GetComponent<AudioSource>().mute = true;
                continueBtn.GetComponent<AudioSource>().mute = true;
                gift.GetComponent<AudioSource>().mute = true;
                giftImage.GetComponent<AudioSource>().mute = true;
                sCubesBtn.GetComponent<AudioSource>().mute = true;
                sBgBtn.GetComponent<AudioSource>().mute = true;
                sMusicBtn.GetComponent<AudioSource>().mute = true;
                withAdsBtn.GetComponent<AudioSource>().mute = true;
                withoutAdsBtn.GetComponent<AudioSource>().mute = true;
                privacyBtn.GetComponent<AudioSource>().mute = true;
            }
        }
    }

    void OnMouseDown()
    {
        transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
    }
    void OnMouseUp()
    {
        transform.localScale = transform.localScale - new Vector3(0.1f, 0.1f, 0.1f);

        switch (gameObject.name)
        {
            case "Shop":
                if (sCubesBtn.transform.localScale.x == 1f) sCubesBtn.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                if (sBgBtn.transform.localScale.x != 1f) sBgBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                if (sMusicBtn.transform.localScale.x != 1f) sMusicBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case "Cubes":
                if (sCubesBtn.transform.localScale.x == 1f) sCubesBtn.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                if (sBgBtn.transform.localScale.x != 1f) sBgBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                if (sMusicBtn.transform.localScale.x != 1f) sMusicBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case "Backgrounds":
                if (sCubesBtn.transform.localScale.x != 1f) sCubesBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                if (sBgBtn.transform.localScale.x == 1f) sBgBtn.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                if (sMusicBtn.transform.localScale.x != 1f) sMusicBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
            case "Musics":
                if (sCubesBtn.transform.localScale.x != 1f) sCubesBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                if (sBgBtn.transform.localScale.x != 1f) sBgBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                if (sMusicBtn.transform.localScale.x == 1f) sMusicBtn.transform.localScale += new Vector3(0.3f, 0.3f, 0.3f);
                break;
        }
    }

    void OnMouseUpAsButton()
    {
        GetComponent<AudioSource>().Play();
        switch (gameObject.name)
        {
            case "Restart":
                SceneManager.LoadScene("Main");
                break;
            case "VK":
                if (PlayerPrefs.GetInt("VKFirstClick") != 1)
                {
                    Social.ReportProgress("CgkI9dLv-YcUEAIQBg", 100.0f, (bool success) =>
                    {
                    });
                    PlayerPrefs.SetInt("VKFirstClick", 1);
                    PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1);
                }
                Camera.main.GetComponent<AudioSource>().Stop();
                Application.OpenURL("https://vk.com/ddrvld_lab");

                //----------------Сброс всего---------------//
                //PlayerPrefs.DeleteAll();
                //------------------------------------------//

                ////////////////////////////////////////////////////////
                //PlayerPrefs.SetInt ("Diamonds", 100);
                //-------------------------Сброс Кол-ва бэкграундов и мелодий-------------------//
                //PlayerPrefs.SetInt ("QuantityBGs", 0);
                //PlayerPrefs.SetInt ("Musics", 0);

                //---------------------Сброс Кубиков---------------------------//
                //PlayerPrefs.SetString ("Cube1", "null");
                //PlayerPrefs.SetString ("Cube2", "null");
                //PlayerPrefs.SetString ("Cube3", "null");
                //PlayerPrefs.SetString ("Cube4", "null");
                //PlayerPrefs.SetString ("Cube5", "null");
                //-------------------------Сброс Бэкграундов-------------------//
                //PlayerPrefs.SetString ("BG1", "null");
                //PlayerPrefs.SetString ("BG2", "null");
                //PlayerPrefs.SetString ("BG3", "null");
                //PlayerPrefs.SetString ("BG4", "null");
                //PlayerPrefs.SetString ("BG5", "null");
                //PlayerPrefs.SetString ("BG6", "null");
                //-------------------------Сброс Музыки------------------------//
                //PlayerPrefs.SetString ("M1", "null");
                //PlayerPrefs.SetString ("M2", "null");
                //PlayerPrefs.SetString ("M3", "null");
                //PlayerPrefs.SetString ("M4", "null");
                //PlayerPrefs.SetString ("M5", "null");
                //PlayerPrefs.SetString ("M6", "null");
                ////////////////////////////////////////////////////////
                break;
            case "Site":
                Camera.main.GetComponent<AudioSource>().Stop();
                Application.OpenURL("http://ddrvld.com/");
                break;
            case "Settings":
                if (!shopBackground.activeSelf)
                {
                    for (int i = 0; i < transform.childCount; i++)
                        transform.GetChild(i).gameObject.SetActive(!transform.GetChild(i).gameObject.activeSelf);
                }
                break;
            case "Music":
                if (PlayerPrefs.GetString("Music") == "off")
                {
                    GetComponent<Image>().sprite = musicOn;
                    PlayerPrefs.SetString("Music", "on");
                    Camera.main.GetComponent<AudioSource>().mute = false;
                }
                else
                {
                    GetComponent<Image>().sprite = musicOff;
                    PlayerPrefs.SetString("Music", "off");
                    Camera.main.GetComponent<AudioSource>().mute = true;
                }
                break;
            case "Sound":
                if (PlayerPrefs.GetString("Sound") == "off")
                {
                    GetComponent<Image>().sprite = soundOn;
                    PlayerPrefs.SetString("Sound", "on");
                    mainCube.GetComponent<AudioSource>().mute = false;
                    detectClicks.GetComponent<AudioSource>().mute = false;
                    whichCube.GetComponent<AudioSource>().mute = false;
                    whichBg.GetComponent<AudioSource>().mute = false;
                    whichMusic.GetComponent<AudioSource>().mute = false;
                    shopBtn.GetComponent<AudioSource>().mute = false;
                    achivBtn.GetComponent<AudioSource>().mute = false;
                    leaderBtn.GetComponent<AudioSource>().mute = false;
                    settingsBtn.GetComponent<AudioSource>().mute = false;
                    musicBtn.GetComponent<AudioSource>().mute = false;
                    soundBtn.GetComponent<AudioSource>().mute = false;
                    vkBtn.GetComponent<AudioSource>().mute = false;
                    backBtn.GetComponent<AudioSource>().mute = false;
                    selectBtn.GetComponent<AudioSource>().mute = false;
                    buyBtn.GetComponent<AudioSource>().mute = false;
                    restartBtn.GetComponent<AudioSource>().mute = false;
                    siteBtn.GetComponent<AudioSource>().mute = false;
                    WatchAdForDiamondBtn.GetComponent<AudioSource>().mute = false;
                    continueBtn.GetComponent<AudioSource>().mute = false;
                    gift.GetComponent<AudioSource>().mute = false;
                    giftImage.GetComponent<AudioSource>().mute = false;
                    sCubesBtn.GetComponent<AudioSource>().mute = false;
                    sBgBtn.GetComponent<AudioSource>().mute = false;
                    sMusicBtn.GetComponent<AudioSource>().mute = false;
                    withAdsBtn.GetComponent<AudioSource>().mute = false;
                    withoutAdsBtn.GetComponent<AudioSource>().mute = false;
                    privacyBtn.GetComponent<AudioSource>().mute = false;
                }
                else
                {
                    GetComponent<Image>().sprite = soundOff;
                    PlayerPrefs.SetString("Sound", "off");
                    mainCube.GetComponent<AudioSource>().mute = true;
                    detectClicks.GetComponent<AudioSource>().mute = true;
                    whichCube.GetComponent<AudioSource>().mute = true;
                    whichBg.GetComponent<AudioSource>().mute = true;
                    whichMusic.GetComponent<AudioSource>().mute = true;
                    shopBtn.GetComponent<AudioSource>().mute = true;
                    achivBtn.GetComponent<AudioSource>().mute = true;
                    leaderBtn.GetComponent<AudioSource>().mute = true;
                    settingsBtn.GetComponent<AudioSource>().mute = true;
                    musicBtn.GetComponent<AudioSource>().mute = true;
                    soundBtn.GetComponent<AudioSource>().mute = true;
                    vkBtn.GetComponent<AudioSource>().mute = true;
                    backBtn.GetComponent<AudioSource>().mute = true;
                    selectBtn.GetComponent<AudioSource>().mute = true;
                    buyBtn.GetComponent<AudioSource>().mute = true;
                    restartBtn.GetComponent<AudioSource>().mute = true;
                    siteBtn.GetComponent<AudioSource>().mute = true;
                    WatchAdForDiamondBtn.GetComponent<AudioSource>().mute = true;
                    continueBtn.GetComponent<AudioSource>().mute = true;
                    gift.GetComponent<AudioSource>().mute = true;
                    giftImage.GetComponent<AudioSource>().mute = true;
                    sCubesBtn.GetComponent<AudioSource>().mute = true;
                    sBgBtn.GetComponent<AudioSource>().mute = true;
                    sMusicBtn.GetComponent<AudioSource>().mute = true;
                    withAdsBtn.GetComponent<AudioSource>().mute = true;
                    withoutAdsBtn.GetComponent<AudioSource>().mute = true;
                    privacyBtn.GetComponent<AudioSource>().mute = true;
                }
                break;
            case "Shop":
                if (GiftTimer.giftReceived)
                {
                    Camera.main.GetComponent<AudioSource>().Stop();
                    diamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
                    if (soundBtn.activeSelf)
                    {
                        for (int i = 0; i < soundBtn.transform.parent.transform.childCount; i++)
                            soundBtn.transform.parent.transform.GetChild(i).gameObject.SetActive(!soundBtn.transform.parent.transform.GetChild(i).gameObject.activeSelf);
                    }
                    if (gift.activeSelf) gift.SetActive(false);
                    else gift.SetActive(true);
                    if (giftTimerText.activeSelf && GiftTimer.timerScore >= 0) giftTimerText.SetActive(false);
                    else if (!giftTimerText.activeSelf && GiftTimer.timerScore > 0) giftTimerText.SetActive(true);
                    if (gameName.activeSelf)
                    {
                        gameName.SetActive(false);
                        tapToPlay.SetActive(false);
                    }
                    else
                    {
                        gameName.SetActive(true);
                        tapToPlay.SetActive(true);
                    }
                    shopBGs.SetActive(false);
                    shopMusics.SetActive(false);
                    shopBackground.SetActive(!shopBackground.activeSelf);
                    if (shopCubes.activeSelf)
                    {
                        shopCubes.SetActive(true);
                        Camera.main.transform.position = new Vector3(100f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    }
                    else
                    {
                        shopCubes.SetActive(false);
                        Camera.main.transform.position = new Vector3(0f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                    }
                }
                break;
            case "Cubes":
                Camera.main.GetComponent<AudioSource>().Stop();
                shopCubes.SetActive(true);
                shopBGs.SetActive(false);
                shopMusics.SetActive(false);
                Camera.main.transform.position = new Vector3(100f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                if (PlayerPrefs.GetInt("QuantityCubes") >= 7) Social.ReportProgress("CgkI9dLv-YcUEAIQBw", 100.0f, (bool success) => {});
                break;
            case "Backgrounds":
                Camera.main.GetComponent<AudioSource>().Stop();
                shopCubes.SetActive(false);
                shopBGs.SetActive(true);
                shopMusics.SetActive(false);
                Camera.main.transform.position = new Vector3(200f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                if (PlayerPrefs.GetInt("QuantityBGs") >= 6) Social.ReportProgress("CgkI9dLv-YcUEAIQCA", 100.0f, (bool success) => {});
                break;
            case "Musics":
                Camera.main.GetComponent<AudioSource>().Stop();
                shopCubes.SetActive(false);
                shopBGs.SetActive(false);
                shopMusics.SetActive(true);
                Camera.main.transform.position = new Vector3(300f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                if (PlayerPrefs.GetInt("Musics") >= 5) Social.ReportProgress("CgkI9dLv-YcUEAIQCQ", 100.0f, (bool success) => {});
                break;
            case "Achievements":
                if (GiftTimer.giftReceived)
                {
                    Camera.main.GetComponent<AudioSource>().Stop();
                    Social.ShowAchievementsUI();
                }
                break;
            case "Leaderboard":
                if (GiftTimer.giftReceived)
                {
                    Camera.main.GetComponent<AudioSource>().Stop();
                    //Social.ShowLeaderboardUI();//Показывает все таблицы рекордов
                    PlayGamesPlatform.Instance.ShowLeaderboardUI("CgkI9dLv-YcUEAIQAg");
                }
                break;
            case "Back":
                Camera.main.GetComponent<AudioSource>().Stop();
                backBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                if (soundBtn.activeSelf)
                {
                    for (int i = 0; i < soundBtn.transform.parent.transform.childCount; i++)
                        soundBtn.transform.parent.transform.GetChild(i).gameObject.SetActive(!soundBtn.transform.parent.transform.GetChild(i).gameObject.activeSelf);
                }
                if (gift.activeSelf) gift.SetActive(false);
                else gift.SetActive(true);
                if (giftTimerText.activeSelf && GiftTimer.timerScore >= 0) giftTimerText.SetActive(false);
                else if (!giftTimerText.activeSelf && GiftTimer.timerScore > 0) giftTimerText.SetActive(true);
                if (gameName.activeSelf)
                {
                    gameName.SetActive(false);
                    tapToPlay.SetActive(false);
                }
                else
                {
                    gameName.SetActive(true);
                    tapToPlay.SetActive(true);
                }
                shopBackground.SetActive(false);
                shopMusics.SetActive(false);
                Camera.main.transform.position = new Vector3(0f, Camera.main.transform.position.y, Camera.main.transform.position.z);
                break;
            case "WatchAdForDiamond":
                Camera.main.GetComponent<AudioSource>().Stop();
                detectClicks.GetComponent<AudioSource>().Stop();
                loseBackground.SetActive(false);
                ADS = 1;
                ShowRewardedVideo();
                break;
            case "Continue":
                Camera.main.GetComponent<AudioSource>().Stop();
                detectClicks.GetComponent<AudioSource>().Stop();
                loseBackground.SetActive(false);
                continueBtn.SetActive(false);
                ADS = 2;
                continueBtn.transform.localScale = new Vector3(1f, 1f, 1f);
                ShowRewardedVideo();
                break;
            case "Gift":
                Camera.main.GetComponent<AudioSource>().Stop();
                if (clickGift)
                {
                    diamonds.GetComponent<Animation>().Play("ScrollDiamonds");
                    randomDiamonds = Random.Range(1, 6);
                    StartCoroutine(pauseForDiamondsAnimation());
                    gift.GetComponent<Animation>().Play("GiftBack");
                    GiftTimer.giftReceived = false;
                    clickGift = false;
                }
                break;
            case "withAdsBtn":
                SceneManager.LoadScene("Main");
                break;
            case "withoutAdsBtn":
                break;
            case "privacyBtn":
                Application.OpenURL("http://ddrvld.com/#privacy");
                break;
        }
    }

    IEnumerator pauseForDiamondsAnimation()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(giveDiamonds());
    }

    IEnumerator giveDiamonds()
    {
        randomCount++;
        giftImage.GetComponent<AudioSource>().Play();
        PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 1);
        diamondsText.text = PlayerPrefs.GetInt("Diamonds").ToString();
        if (randomCount < randomDiamonds)
        {
            yield return new WaitForSeconds(0.7f);
            StartCoroutine(giveDiamonds());
        }
        else
        {
            diamonds.GetComponent<Animation>().Play("ScrollDiamondsBack");
            giftTimerText.SetActive(true);
            GiftTimer.checkTime();
            GiftTimer.giftIsReady = false;
            GiftTimer.giftReceived = true;
            PlayerPrefs.SetInt("rightTime", GiftTimer.currentTime + GiftTimer.fourHour);
            randomCount = 0;
        }
    }

    void ResumeGame()
    {
        loseBackground.SetActive(false);
        mainCube.SetActive(true);
        mainCube.GetComponent<Rigidbody>().isKinematic = true;
        mainCube.GetComponent<Rigidbody>().isKinematic = false;
        if (CubeJump.count_blocks == 1) mainCube.transform.position = new Vector3(allCubes.transform.GetChild(1).position.x, allCubes.transform.GetChild(1).position.y + 2, 0f);
        else mainCube.transform.position = new Vector3(allCubes.transform.GetChild(2).position.x, allCubes.transform.GetChild(2).position.y + 2, 0f);
        mainCube.transform.eulerAngles = new Vector3(0f, 0f, 0f);
        CubeJump.lose = false;
        CubeJump.adsLose = false;
        CubeJump.jump = false;
        CubeJump.nextBlock = true;
        ResumeTimer.timeLeft = 5;
        Camera.main.GetComponent<AudioSource>().enabled = true;
        Camera.main.GetComponent<AudioSource>().Play();
    }

    void ShowRewardedVideo()
    {
        ShowOptions options = new ShowOptions();
        options.resultCallback = HandleShowResult;

        Advertisement.Show("rewardedVideo", options);
    }

    void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished && ADS == 1)
        {
            Debug.Log("Video completed - Offer a reward to the player");
            PlayerPrefs.SetInt("Diamonds", PlayerPrefs.GetInt("Diamonds") + 4);
            SceneManager.LoadScene("Main");
        }
        else if (result == ShowResult.Finished && ADS == 2) ResumeGame();
        else if (result == ShowResult.Skipped) SceneManager.LoadScene("Main");
        else if (result == ShowResult.Failed) SceneManager.LoadScene("Main");
    }
}