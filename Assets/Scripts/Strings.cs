using UnityEngine;
using UnityEngine.UI;

public class Strings : MonoBehaviour {

    public Text play, study, price, continueT, close;
    public static string mainNotif, secondNotif, playText, studyText, topText, toGiftText, priceText, continueText, closeText;

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
            priceText = "Всё по 20";
            continueText = "Продолжить?";
            closeText = "Нажмите ещё раз, чтобы выйти";
        }
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            mainNotif = "A gift is ready!";
            secondNotif = "Come and get it";
            playText = "Tap to play";
            studyText = "Touch, hold then release";
            topText = "Best: ";
            toGiftText = "\nTo gift";
            priceText = "All for 20";
            continueText = "Continue?";
            closeText = "Click again to exit";
        }
        else
        {
            mainNotif = "A gift is ready!";
            secondNotif = "Come and get it";
            playText = "Tap to play";
            studyText = "Touch, hold then release";
            topText = "Best: ";
            toGiftText = "\nTo gift";
            priceText = "All for 20";
            continueText = "Continue?";
            closeText = "Click again to exit";
        }
        setText();
    }
	
	void setText ()
    {
        play.text = playText;
        study.text = studyText;
        price.text = priceText;
        continueT.text = continueText;
        close.text = closeText;
    }
}