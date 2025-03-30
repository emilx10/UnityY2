using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.Audio;

public class SettingsMenuUI : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    
    public AudioMixer audioMixer;
    
    private Resolution[] resolutions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadVolumeSettings();
        SetupResolutions();
        fullscreenToggle.isOn = Screen.fullScreen;
        
        audioMixer.GetFloat("MasterVolume", out float master);
        audioMixer.GetFloat("MusicVolume", out float music);
        audioMixer.GetFloat("SFXVolume", out float sfx);

        masterVolumeSlider.value = Mathf.Pow(10, master / 20f);
        musicVolumeSlider.value = Mathf.Pow(10, music / 20f);
        sfxVolumeSlider.value = Mathf.Pow(10, sfx / 20f);
    }

     void SetupResolutions()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        var options = new List<string> ();

        int current = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option))
            {
                options.Add(option);
            }

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                current = i;
            }
        }
        
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = current;
        resolutionDropdown.RefreshShownValue();
    }

    public void ApplySettings()
    {
        Resolution selectedResolution = resolutions[resolutionDropdown.value];
        Screen.SetResolution(selectedResolution.width, selectedResolution.height, fullscreenToggle.isOn);
        Debug.Log($"Resolution set to: {selectedResolution.width}x{selectedResolution.height}");
        
        SetVolume("MasterVolume", masterVolumeSlider.value);
        SetVolume("MusicVolume", musicVolumeSlider.value);
        SetVolume("SFXVolume", sfxVolumeSlider.value);
        SaveVolumeSettings();
    }

    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolumeSlider.value);
        PlayerPrefs.Save();
    }

    private void LoadVolumeSettings()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicVolumeSlider.value  = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxVolumeSlider.value    = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    void SetVolume(string exposedParamater, float value)
    {
        float volume = Mathf.Log10(Mathf.Clamp(value, 0.001f, 1f)) * 20f;
        audioMixer.SetFloat(exposedParamater, volume);
    }
    
}
