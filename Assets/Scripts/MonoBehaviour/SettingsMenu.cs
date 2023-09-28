using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private TMP_Dropdown FPSDropdown;
    public Dropdown dropdown;

    private void Start(){
        loadVolumes();
        loadFPS();
    }
    public void setVolume(float volume){
        SoundManager.SetSFXVolume(volume);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public void setMusicVolume(float volume)
    {
        SoundManager.SetMusicVolume(volume);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private void loadVolumes(){
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        setMusicVolume(musicSlider.value);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        setMusicVolume(SFXSlider.value);
    }

    public void SetQuality(int qualityIndex){
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFPS(int index){
        int fps;
        if(index == 0){
            fps = 30;
        } else if(index == 1){
            fps = 60;
        } else {
            fps = 120;
        }
        PlayerPrefs.SetInt("FPS", fps);
        Application.targetFrameRate = PlayerPrefs.GetInt("FPS");
    }

    private void loadFPS(){
        int index;
        int fps = PlayerPrefs.GetInt("FPS");
        if(fps == 30){
            index = 0;
        } else if(fps == 60){
            index = 1;
        } else {
            index = 2;
        }
        FPSDropdown.value = index;
    }
}
