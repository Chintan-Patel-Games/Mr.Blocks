using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject levelPanel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI gameOverText;
    public Button restartBtn;
    public Button menuBtn;
    public LevelManager levelManager;
    private SoundManager soundManager;
    public int levelNumber = 1;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        AddListeners();
    }

    private void Start()
    {
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        levelText.text = "Level " + levelNumber;
    }

    private void AddListeners()
    {
        restartBtn.onClick.AddListener(RestartButton);
        menuBtn.onClick.AddListener(MainMenuButton);
    }

    private void GameOverPanelStatus(bool status)
    {
        gameOverPanel.SetActive(status);
    }

    private void LevelPanelStatus(bool status)
    {
        levelPanel.SetActive(status);
    }

    public void ShowGameWinUI()
    {
        GameOverPanelStatus(true);

        gameOverText.text = "Game Completed!!";
        gameOverText.color = Color.green;
        LevelPanelStatus(false);
    }

    public void ShowGameLoseUI()
    {
        GameOverPanelStatus(true);

        gameOverText.text = "Game Over!!";
        gameOverText.color = Color.red;
        LevelPanelStatus(false);
    }

    private void RestartButton()
    {
        soundManager.PlayButtonClickAudio();
        levelManager.RestartLevel();
    }

    private void MainMenuButton()
    {
        soundManager.PlayButtonClickAudio();
        soundManager.DestroySoundManager();  // Destroy the current SoundManager
        levelManager.LoadMainMenu();
    }
}