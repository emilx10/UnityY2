using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreenUI : MonoBehaviour
{
    public Text bestTimeText;

    public void Show(int levelIndex)
    {
        gameObject.SetActive(true);
        LevelTimer.Instance.StopTimer();
        float bestTime = ProgressManager.instance.progress.levels[levelIndex].bestTime;
        string formattedTime= FormatTime(bestTime);
        bestTimeText.text = $"Best Time: {formattedTime}";
    }

    private string FormatTime(float timeInSeconds)
    {
       int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
       int seconds = Mathf.FloorToInt(timeInSeconds % 60f);
       int miliseconds = Mathf.FloorToInt((timeInSeconds * 100) % 100);
       return $"{minutes:00}:{seconds:00}.{miliseconds:00}";
    }
}
