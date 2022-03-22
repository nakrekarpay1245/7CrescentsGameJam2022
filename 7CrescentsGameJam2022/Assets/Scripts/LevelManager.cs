using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int money;

    public int bonusPrice;

    [SerializeField]
    private float time;

    public int necessaryElectronCount;

    [HideInInspector]
    public int currentElectronCount;

    [HideInInspector]
    public float remainingTime;

    public static LevelManager levelManager;

    private void Awake()
    {
        if (levelManager == null)
        {
            levelManager = this;
        }
        remainingTime = time;
        currentElectronCount = 0;
    }

    private void Update()
    {
        if (currentElectronCount >= necessaryElectronCount)
        {
            //Debug.Log("Level Completed");
            UserInterfaceManager.userInterfaceManager.LevelCompleted();
        }
        else
        {
            if (remainingTime <= 0)
            {
                if (currentElectronCount < necessaryElectronCount)
                {
                   // Debug.Log("Level Over");
                    UserInterfaceManager.userInterfaceManager.LevelOver();
                }
                else
                {
                   // Debug.Log("Level Completed");
                    UserInterfaceManager.userInterfaceManager.LevelCompleted();
                }
            }
            else
            {
                remainingTime -= Time.deltaTime;
            }
        }
    }

    public void IncreaseElectronCount()
    {
        currentElectronCount++;
        money += 5;
    }
    public void DecreaseElectronCount()
    {
        currentElectronCount--;
    }

    public void RemainingTimeBonus()
    {
        remainingTime += 10;
    }

    public void SceneStarter(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SceneStarter(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void TimeChanger(float myTimeScale)
    {
        Time.timeScale = myTimeScale;
    }
}
