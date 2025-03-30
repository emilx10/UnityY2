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

    public void RegisterEnemy(GameObject enemy)
    {
        if (!activeEnemies.Contains(enemy))
        {
            activeEnemies.Add(enemy);
        }
    }

    public void EnemyDied(GameObject enemy)
    {
        if (activeEnemies.Contains(enemy))
        {
            activeEnemies.Remove(enemy);
        }

        if (activeEnemies.Count == 0)
        {
            Debug.Log("all enemies le dead, level le complete");
            LevelTimer.Instance?.StopTimer();
            int levelIndex = SceneManager.GetActiveScene().buildIndex - 1;
            float currentTime = LevelTimer.Instance.currentTime;
            
            ProgressManager.instance?.CompleteLevel(levelIndex,currentTime);

            if (timeText != null)
            {
                timeText.text = $"Time: {currentTime}";
            }

            if (bestTimeText != null)
            {
                float best = ProgressManager.instance.progress.levels[levelIndex].bestTime;
                bestTimeText.text =$" Best Time: {FormatTime(best)}";
            }

            if (successScreen != null)
            {
                successScreen.SetActive(true);
                Time.timeScale = 0f;
            }
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

