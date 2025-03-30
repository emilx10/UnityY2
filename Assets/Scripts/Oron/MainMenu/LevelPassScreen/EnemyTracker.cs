using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyTracker : MonoBehaviour
{
    public static EnemyTracker Instance;

    private List<GameObject> activeEnemies = new List<GameObject>();

    [SerializeField] private GameObject successScreen;
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI bestTimeText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Find all the enemy objects in the scene by tag, and add them to the activeEnemies list.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            activeEnemies.Add(enemy);
        }
    }

    private void Update()
    {
        // Check if all enemies are deactivated (SetActive(false))
        bool allEnemiesDead = true;

        foreach (GameObject enemy in activeEnemies)
        {
            if (enemy.activeSelf) // If the enemy is still active, the player hasn't won yet
            {
                allEnemiesDead = false;
                break;
            }
        }

        if (allEnemiesDead)
        {
            HandleLevelCompletion();
        }
    }

    private void HandleLevelCompletion()
    {
        // Stop the level timer
        LevelTimer.Instance?.StopTimer();

        // Get the current level index and time
        int levelIndex = SceneManager.GetActiveScene().buildIndex - 1;
        float currentTime = LevelTimer.Instance.currentTime;

        // Complete the level and save progress
        ProgressManager.instance?.CompleteLevel(levelIndex, currentTime);

        // Update the UI with the time and best time
        if (timeText != null)
        {
            timeText.text = $"Time: {currentTime}";
        }

        if (bestTimeText != null)
        {
            float best = ProgressManager.instance.progress.levels[levelIndex].bestTime;
            bestTimeText.text = $"Best Time: {FormatTime(best)}";
        }

        // Show the success screen and pause the game
        if (successScreen != null)
        {
            successScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100);
        return $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }
}
