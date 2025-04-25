using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public SettingsMenuUI settingsMenuUI;
    
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (settingsMenu != null && settingsMenu.activeSelf)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f: 1f;
    }
    public void OpenSettings()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void ReturnFromSettings()
    {
        settingsMenu.SetActive(false);
        if (isPaused)
        {
            pauseMenu.SetActive(true);
        }
    }
    public void ApplySettingsFromPause()
    {
        if (settingsMenuUI != null)
        {
            settingsMenuUI.ApplySettings();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
