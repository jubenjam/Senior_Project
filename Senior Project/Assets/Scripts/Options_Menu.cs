using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio; 
using UnityEngine.UI;
using TMPro;

public class Options_Menu : MonoBehaviour
{
    //audioMixer for volume control
    public AudioMixer audioMixer;

    public TMP_Dropdown resolutionDropdown;
    //Array of resolutions the computer can use
    Resolution[] resolutions;

    void Start()
    {
        //find all possible resolutions and clear placeholders
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        //turn resolutions into strings and find current index for dropdown
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //add correct resolution values and show current resolution
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //set resolution when changed in dropdown
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //set volume when changed with slider
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    //set quality when changed with dropdown
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //enter/exit fullscreen when changed with toggle
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}