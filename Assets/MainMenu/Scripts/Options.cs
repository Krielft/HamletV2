using System.Collections.Generic;
using Hamlet.Game.Runtime.Player;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [Header("Options Variables")] 
        public TMP_Dropdown resDropdown;
        public Toggle fullScreenToggle;

        public AudioMixer[] audioMixers;
        public Slider[] audioSliders;
        
        public Resolution[] resolutions;
        public List<Resolution> filteredRes;

        private float currentRate;
        private int currentResIndex;
        private bool currentScreenState = true;

    void Start()
    {
        SetupResolutions();
        for (int i = 0; i < 3; i++)
        {
            audioMixers[i].SetFloat("MasterVolume",PlayerPrefs.GetFloat("Volume"+i, 0f));
            audioSliders[i].value = PlayerPrefs.GetFloat("Volume" + i, 0f);
        }
    }

    void SetupResolutions()
    {
        //Setup all the available resolutions
        
        resolutions = Screen.resolutions;
        filteredRes = new List<Resolution>();
        
        resDropdown.ClearOptions();
        currentRate = Screen.currentResolution.refreshRate;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRate)
            {
                filteredRes.Add(resolutions[i]);
            }
        }
        
        List<string> options = new List<string>();
        for (int i = 0; i < filteredRes.Count; i++)
        {
            string resOption = filteredRes[i].width + "x" + filteredRes[i].height + " " + filteredRes[i].refreshRate + "Hz";
            options.Add(resOption);
        }
        
        resDropdown.AddOptions(options);
        resDropdown.value = Mathf.Max(options.Count);
        resDropdown.RefreshShownValue();
    }

    public void SetResolution()
    {
        //Set the game's window Resolution by the player's chosen option
        Resolution resolution = filteredRes[resDropdown.value];
        Screen.SetResolution(resolution.width, resolution.height, currentScreenState, resolution.refreshRate);
    }

    public void SetScreenState()
    {
        //Set the game's window to Full Screen or not
        currentScreenState = fullScreenToggle.isOn;
        Screen.fullScreen = currentScreenState;
    }
        
    public void SetResolution(int width, int height, bool screenState)
    {
        //Set the game's resolution & screen type by the selected option
        Screen.SetResolution(width, height, screenState);
    }
    
    public void SetVolume(int index)
    {
        //Set the game's global volume by the player's chosen amount
        audioMixers[index].SetFloat("MasterVolume", audioSliders[index].value);
        PlayerPrefs.SetFloat("Volume" + index, audioSliders[index].value);
    }
}