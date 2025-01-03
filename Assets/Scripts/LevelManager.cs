using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public UIManager uIManager;
    private int currentSceneIndex = 0;
    private const int mainMenuIndex = 0;
    
    private void Start() => currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

    public void OnLevelComplete() => LoadNextLevel();

    private void LoadNextLevel()
    {
        int totalNumberOfScenes = SceneManager.sceneCountInBuildSettings;

        if(currentSceneIndex + 1 < totalNumberOfScenes)
            SceneManager.LoadScene(currentSceneIndex + 1);
        else
            uIManager.ShowGameWinUI();
    }

    public void OnPlayerDeath() => uIManager.ShowGameLoseUI();

    public void RestartLevel() => SceneManager.LoadScene(currentSceneIndex);

    public void LoadMainMenu() => SceneManager.LoadScene(mainMenuIndex);
}