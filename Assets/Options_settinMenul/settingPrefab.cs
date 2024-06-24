using System.Collections;
using System.Collections.Generic;
//using UnityEditor.iOS.Xcode;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;
using System;

public class settingPrefab : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField ] Dropdown resolutionDropdown;
  //  public Dropdown qualityDropdown;
    //public Dropdown textureDropdown;
  //  public Dropdown aaDropdown;
    public Slider volumeSlider;
    float currentVolume;
    Resolution[] resolutions;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;

    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen= isFullscreen;
    }
    public void SetResoulution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); ;
    }
  /*  public void SetTextureQuality(int textureIndex)
    {
        QualitySettings.globalTextureMipmapLimit = textureIndex;
        qualityDropdown.value = 6;

    }
    public void SetAntiAliasing(int aaIndex)
    {
        QualitySettings.antiAliasing=aaIndex;
        qualityDropdown.value = 6;

    }
    public void SetQuality(int qualityIndex) {
        if (qualityIndex != 6) QualitySettings.SetQualityLevel(qualityIndex);
            switch(qualityIndex)
            {
            case 0:
                textureDropdown.value = 3;
                aaDropdown.value = 0;
                break;
            case 1:
                textureDropdown.value = 2;
                aaDropdown.value = 0;
                break;
            case 2:
                textureDropdown.value = 1;
                aaDropdown.value = 0;
                break;
            case 3:
                textureDropdown.value = 0;
                aaDropdown.value = 0;
                break;
            case 4:
                textureDropdown.value = 0;
                aaDropdown.value = 1;
                break;
            case 5:
                textureDropdown.value= 0;
                aaDropdown.value = 2;
                break;

            }
        qualityDropdown.value = qualityIndex;
    }*/
    public void SaveSettings()
    {
        //PlayerPrefs.SetInt("QualitySettingPreference", qualityDropdown.value);
      //  PlayerPrefs.SetInt("ResolutionPreference", textureDropdown.value);
      //  PlayerPrefs.SetInt("AntiAliasingPreference", aaDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",Convert.ToInt32(Screen.fullScreen));
        PlayerPrefs.SetFloat("VolumePreference", currentVolume);
    }
    public void LoadSettings(int currentResolutionIntdex)
    {
        /*if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value =
                         PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            resolutionDropdown.value =
                         PlayerPrefs.GetInt("ResolutionPreference");
        else
            resolutionDropdown.value = currentResolutionIntdex;
        if (PlayerPrefs.HasKey("TextureQualityPreference"))
            textureDropdown.value =
                         PlayerPrefs.GetInt("TextureQualityPreference");
        else
            textureDropdown.value = 0;
        if (PlayerPrefs.HasKey("AntiAliasingPreference"))
            aaDropdown.value =
                         PlayerPrefs.GetInt("AntiAliasingPreference");
        else
            aaDropdown.value = 1;*/
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen =
            Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
    }
   
    public void BackToMenul()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
    public void Start()
    {
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " +
                     resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width
                  && resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }
}
