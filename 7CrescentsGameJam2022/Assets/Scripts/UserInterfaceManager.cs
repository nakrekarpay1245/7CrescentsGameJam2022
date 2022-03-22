using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Text remainingTimeText;

    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private Text electronText;

    //[SerializeField]
    //private GameObject retryButton;

    [SerializeField]
    private GameObject nextButton;

    //[SerializeField]
    //private GameObject menuButton;

    [SerializeField]
    private GameObject levelCompleted;

    [SerializeField]
    private GameObject levelFailed;

    //Bonus Buttons
    [SerializeField]
    private GameObject addElectronButton;

    [SerializeField]
    private GameObject speedButton;

    [SerializeField]
    private GameObject magnetButton;

    [SerializeField]
    private GameObject timeButton;


    public static UserInterfaceManager userInterfaceManager;

    private void Awake()
    {
        if (userInterfaceManager == null)
        {
            userInterfaceManager = this;
        }

        //retryButton.SetActive(false);
        nextButton.SetActive(false);
        //menuButton.SetActive(false);
    }

    private void Update()
    {
        int minute = (((int)LevelManager.levelManager.remainingTime) / 60);
        int second = (((int)LevelManager.levelManager.remainingTime) % 60);
        int money = LevelManager.levelManager.money;
        int currentElectron = LevelManager.levelManager.currentElectronCount;
        int necessaryElectron = LevelManager.levelManager.necessaryElectronCount;

        remainingTimeText.text = minute + " : " + second;
        moneyText.text = "MONEY : " + money;
        electronText.text = "Electron : " + currentElectron + " / " + necessaryElectron;
    }

    public void LevelOver()
    {
        //retryButton.SetActive(true);
        nextButton.SetActive(false);
        //menuButton.SetActive(true);
        levelFailed.SetActive(true);
    }

    public void LevelCompleted()
    {
        //retryButton.SetActive(false);
        nextButton.SetActive(true);
        //menuButton.SetActive(true);
        levelCompleted.SetActive(true);
    }

    public void AddElectronBonus()
    {
        if (LevelManager.levelManager.money >= LevelManager.levelManager.bonusPrice)
        {
            LevelManager.levelManager.money -= LevelManager.levelManager.bonusPrice;
            PlayerBonus.playerBonus.AddElectronBonus();
            addElectronButton.SetActive(false);
            Invoke("AddElectronActive", 5);
        }
    }

    public void SpeedBonus()
    {
        if (LevelManager.levelManager.money >= LevelManager.levelManager.bonusPrice)
        {
            LevelManager.levelManager.money -= LevelManager.levelManager.bonusPrice;
            PlayerBonus.playerBonus.IncreasePlayerSpeed();
            speedButton.SetActive(false);
            Invoke("SpeedActive", 5);
        }
    }

    public void MagnetBonus()
    {
        if (LevelManager.levelManager.money >= LevelManager.levelManager.bonusPrice)
        {
            LevelManager.levelManager.money -= LevelManager.levelManager.bonusPrice;
            PlayerBonus.playerBonus.Magnet();
            magnetButton.SetActive(false);
            Invoke("MagnetActive", 5);
        }
    }

    public void TimeBonus()
    {
        if (LevelManager.levelManager.money >= LevelManager.levelManager.bonusPrice)
        {
            LevelManager.levelManager.money -= LevelManager.levelManager.bonusPrice;
            LevelManager.levelManager.RemainingTimeBonus();
            timeButton.SetActive(false);
            Invoke("TimeActive", 10);
        }
    }

    public void AddElectronActive()
    {
        addElectronButton.SetActive(true);
    }

    public void SpeedActive()
    {
        speedButton.SetActive(true);
    }

    public void MagnetActive()
    {
        magnetButton.SetActive(true);
    }

    public void TimeActive()
    {
        timeButton.SetActive(true);
    }
}
