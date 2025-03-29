using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
   public GameObject levelButtonPrefab;
   public Transform buttonContainer;
   public Texture[] LevelThumbnails;

   private void Start()
   {
      GenerateButtons();
   }

   void GenerateButtons()
   {
      var progress = ProgressManager.instance.progress;

      for (int i = 0; i < progress.levels.Count; i++)
      {
         int levelIndex = i;
         bool isUnlocked = progress.levels[i].isUnlocked;
         
         GameObject buttonObject = Instantiate(levelButtonPrefab, buttonContainer);
         
         // references to setup button
         Button btn = buttonObject.GetComponent<Button>();
         RawImage thumbnail = buttonObject.transform.Find("Thumbnail").GetComponent<RawImage>();
         Image overlay = buttonObject.transform.Find("Overlay").GetComponent<Image>();
         RawImage lockIcon = buttonObject.transform.Find("LockIcon").GetComponent<RawImage>();
         Text levelText = buttonObject.transform.Find("LevelText").GetComponent<Text>();
         
         // setting the level text :)
         levelText.text = "Level " + (i + 1);
         
         // set thumbnail image :3
         if (LevelThumbnails.Length > i && LevelThumbnails[i] != null)
         {
            thumbnail.texture = LevelThumbnails[i];
         }

         if (isUnlocked)
         {
            overlay.gameObject.SetActive(false);
            lockIcon.gameObject.SetActive(false);
            btn.interactable = true;
            
            btn.onClick.AddListener(() =>
            {
               StartCoroutine(LoadLevelAsync(levelIndex));
            });
         }
         else
         {
            overlay.gameObject.SetActive(true);
            lockIcon.gameObject.SetActive(true);
            btn.interactable = false;
         }
      }

      IEnumerator LoadLevelAsync(int levelIndex)
      {
         string sceneName= "Level" + (levelIndex + 1);
         AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
         while (!asyncLoad.isDone)
         {
            yield return null;   
         }
      }
   }
}
