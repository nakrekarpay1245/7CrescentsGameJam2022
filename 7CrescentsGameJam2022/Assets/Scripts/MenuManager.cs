using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }
    public void SceneStarter(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void SceneStarter(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
