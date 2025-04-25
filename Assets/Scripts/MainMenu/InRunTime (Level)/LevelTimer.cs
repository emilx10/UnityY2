
using System;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public static LevelTimer Instance;
    
    private float timeElapsed;
    private bool isRunning = true;
    public float currentTime => timeElapsed;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isRunning)
        {
            timeElapsed += Time.deltaTime;
        }
    }
    public void StopTimer() => isRunning = false;
}
