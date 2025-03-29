using System.IO;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
   public static ProgressManager instance;
   
   public PlayerProgress progress;

   private string savePath;

   private void Awake()
   {
      if (instance == null)
      {
         instance = this;
         DontDestroyOnLoad((gameObject));

         savePath = Path.Combine(Application.persistentDataPath, "progress.json");
         LoadProgress();
      }

      else
      {
         Destroy(gameObject);
      }
   }

   public void LoadProgress()
   {
      if (File.Exists(savePath))
      {
         string jsonString = File.ReadAllText(savePath);
         progress = JsonUtility.FromJson<PlayerProgress>(jsonString);
      }
      else
      {
         InitializeProgress();
      }
   }

   public void SaveProgress()
   {
      string jsonString = JsonUtility.ToJson(progress, true);
      File.WriteAllText(savePath, jsonString);
   }

   private void InitializeProgress()
   {
      int MaxLevel = 10;
      progress = new PlayerProgress();
      for (int i = 0; i < MaxLevel; i++)
      {
         progress.levels.Add((new LevelProgress
         {
            isUnlocked = i == 0, 
            bestTime = 0f
         }));
      }
      SaveProgress();
   }
}
