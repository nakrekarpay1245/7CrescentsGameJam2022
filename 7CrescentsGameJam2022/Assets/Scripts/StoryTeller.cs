using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StoryTeller : MonoBehaviour
{
    [TextArea(10, 10)]
    public string story;
    AudioSource audioSource;

    public Text storyText;

    public GameObject storyPanel;
    public GameObject passButton;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        storyPanel.SetActive(true);

        StartCoroutine(TypeSentence());
    }

    IEnumerator TypeSentence()
    {
        storyText.text = "";
        foreach (char letter in story.ToCharArray())
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            storyText.text += letter;
            yield return new WaitForSeconds(0.075f);
        }
        Invoke("EndStory", 5);
    }
    public void EndStory()
    {
        storyPanel.SetActive(false);
    }

    public void Pass()
    {
        passButton.SetActive(false);
        storyText.text = story;
        Invoke("EndStory", 3);
        StopAllCoroutines();
    }
}


