using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private SoundManager soundManager;
    public Button playButton;
    public Button quitButton;

    private const int firstLevel = 1;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        AddListeners();
    }

    private void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    public void Play()
    {
        soundManager.PlayButtonClickAudio();
        SceneManager.LoadScene(firstLevel);
    }

    public void Quit()
    {
        #if UNITY_WEBGL
        // Show a native browser alert
        Application.ExternalEval("alert('Thank you for playing! Please close the browser tab to exit.');");
        #else
        Application.Quit();
        #endif
    }
}