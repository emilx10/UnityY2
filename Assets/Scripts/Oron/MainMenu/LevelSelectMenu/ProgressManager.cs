using System.IO;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
   public static ProgressManager instance;
   
   public PlayerProgress progress;

   private string savePath;
   [SerializeField] private int maxLevel = 10;
   public int Maxlevels => maxLevel;

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

   public void CompleteLevel(int levelIndex, float completionTime)
   {
      if (levelIndex < 0 || levelIndex >= progress.levels.Count)
      {
         return;
      }
      var level = progress.levels[levelIndex];

      if (level.bestTime == 0f || completionTime < level.bestTime)
      {
         level.bestTime = completionTime;
      }

      if (levelIndex + 1 < progress.levels.Count)
      {
         progress.levels[levelIndex + 1].isUnlocked = true;
      }
      SaveProgress();
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
   
      progress = new PlayerProgress();
      for (int i = 0; i < maxLevel; i++)
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
