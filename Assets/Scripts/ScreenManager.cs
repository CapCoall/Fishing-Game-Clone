using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;

    private GameObject currentScreen;

    public GameObject endScreen;
    public GameObject gameScreen;
    public GameObject mainScreen;
    public GameObject returnScreen;

    public Button lengthButton;
    public Button strengthButton;
    public Button offlineButton;

    public Text gameScreenMoney;
    public Text lengthCostText;
    public Text lengthValueText;
    public Text strengthCostText;
    public Text strenthValueText;
    public Text offlineCostText;
    public Text offlineValueText;
    public Text endScreenMoney;
    public Text returnScreenMoney;

    private int gameCount;

    private void Awake()
    {
        if (ScreenManager.instance)
            Destroy(base.gameObject);
        else
            ScreenManager.instance = this;
        currentScreen = mainScreen;

    }
    private void Start()
    {
        CheckIdles();
        UpdateTexts();

    }
    public void ChangeScreen(Screens screen)
    {
        currentScreen.SetActive(false);
        switch (screen)
        {
            case Screens.MAIN:
                currentScreen = mainScreen;
                UpdateTexts();
                CheckIdles();
                break;

            case Screens.GAME:
                currentScreen = gameScreen;
                gameCount++;
                break;

            case Screens.END:
                currentScreen = endScreen;
                SetEndScreenMoney();
                break;
            case Screens.RETURN:
                currentScreen = returnScreen;
                SetReturnScreenMoney();
                break;
        }
        currentScreen.SetActive(true);
    }
    public void SetEndScreenMoney()
    {
        endScreenMoney.text = "$" + �dleManager.instance.totalGain;
    }
    public void SetReturnScreenMoney()
    {
        returnScreenMoney.text = "$" + �dleManager.instance.totalGain + " gained while waiting!";
    }
    public void UpdateTexts()
    {
        gameScreenMoney.text = "$" + �dleManager.instance.wallet;
        lengthCostText.text = "$" + �dleManager.instance.lengthCost;
        lengthValueText.text = -�dleManager.instance.length + "m";
        strengthCostText.text = "$" + �dleManager.instance.strengthCost;
        strenthValueText.text = �dleManager.instance.strength + "fishes.";
        offlineCostText.text = "$" + �dleManager.instance.offlineEarningsCosts;
        offlineValueText.text = "$" + �dleManager.instance.offlineEarnings+"/min";
    }
    public void CheckIdles()
    {
        int lengthCost = �dleManager.instance.lengthCost;
        int strengthCost = �dleManager.instance.strengthCost;
        int offlineEarningsCost = �dleManager.instance.offlineEarningsCosts;
        int wallet = �dleManager.instance.wallet;

        if (wallet < lengthCost)
            lengthButton.interactable = false;
        else
            lengthButton.interactable = true;

        if (wallet < strengthCost)
            strengthButton.interactable = false;
        else
            strengthButton.interactable = true;

        if (wallet < offlineEarningsCost)
            offlineButton.interactable = false;
        else
            offlineButton.interactable = true;
    }
}
