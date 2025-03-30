using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayHUD : MonoBehaviour
{
    public Weapon weapon;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI timerText;
    
    
    // Update is called once per frame
    void Update()
    {
        if (weapon != null & ammoText != null)
        {
            ammoText.text = $"Ammo: {weapon.GetAmmo()}";
        }

        if (LevelTimer.Instance != null && timerText != null)
        {
            float time = LevelTimer.Instance.currentTime;
            timerText.text = $"Time: {FormatTime(time)}";
        }
    }
    
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);
        return $"{minutes:00}:{seconds:00}.{milliseconds:00}";
    }
}
