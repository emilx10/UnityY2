using System;
using UnityEngine;

public class PersistentMusic : MonoBehaviour
{
   public static PersistentMusic Instance;
   private AudioSource audioSource;

   private void Awake()
   {
       if (Instance != null && Instance != this)
       {
           Destroy(gameObject);
           return;
       }
       Instance = this;
       DontDestroyOnLoad(gameObject);
       audioSource = GetComponent<AudioSource>();
       if (!audioSource.isPlaying)
       {
           audioSource.Play();
       }
   }

   // Update is called once per frame
    void Update()
    {
        
    }
}
