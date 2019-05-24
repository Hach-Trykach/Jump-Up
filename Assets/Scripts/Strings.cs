using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Strings : MonoBehaviour {

    public Text play, study, price, continueT, close, Ads, withAds, withoutAds, privacy;
    public static string mainNotif, secondNotif, playText, studyText, topText, toGiftText, priceText, continueText, closeText, AdsText, withAdsText, withoutAdsText, privacyBtnText;

    void Start()
    {
        if (Application.systemLanguage == SystemLanguage.Russian)
        {
            mainNotif = "Подарок готов!";
            secondNotif = "Зайди и получи его";
            playText = "Коснитесь, чтобы начать";
            studyText = "Нажмите, держите, затем отпустите";
            topText = "Рекорд: ";
            toGiftText = "\nДо подарка";
            priceText = "20";
            continueText = "Продолжить?";
            closeText = "Нажмите ещё раз, чтобы выйти";
            AdsText = "Реклама помогает нам сохранить эту игру бесплатной. Наша политика конфиденциальности объясняет, как обрабатывается ваша информация, чтобы показывать вам соответствующие объявления.";
            withAdsText = "Играть бесплатно с рекламой";
            withoutAdsText = "Купить версию без рекламы";
            privacyBtnText = "Политика конфиденциальности";
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            mainNotif = "A gift is ready!";
            secondNotif = "Come and get it";
            playText = "Tap to play";
            studyText = "Touch, hold then release";
            topText = "Best: ";
            toGiftText = "\nTo gift";
            priceText = "20";
            continueText = "Continue?";
            closeText = "Click again to exit";
            AdsText = "Advertisements help us keep this game free. Our privacy policy explains how your information is processed in order to show you appropriate ads.";
            withAdsText = "Play FREE with Ads";
            withoutAdsText = "Buy version without ads";
            privacyBtnText = "Privacy Policy";
        }
        else
        {
            mainNotif = "A gift is ready!";
            secondNotif = "Come and get it";
            playText = "Tap to play";
            studyText = "Touch, hold then release";
            topText = "Best: ";
            toGiftText = "\nTo gift";
            priceText = "20";
            continueText = "Continue?";
            closeText = "Click again to exit";
            AdsText = "Advertisements help us keep this game free. Our privacy policy explains how your information is processed in order to show you appropriate ads.";
            withAdsText = "Play FREE with Ads";
            withoutAdsText = "Buy version without ads";
            privacyBtnText = "Privacy Policy";
        }
        setText();
    }
	
	void setText ()
    {
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name == "Main")
        {
            play.text = playText;
            study.text = studyText;
            price.text = priceText;
            continueT.text = continueText;
            close.text = closeText;
        }
        else
        {
            Ads.text = AdsText;
            withAds.text = withAdsText;
            withoutAds.text = withoutAdsText;
            privacy.text = privacyBtnText;
        }
    }
}