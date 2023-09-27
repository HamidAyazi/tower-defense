using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;

    public void setVolume(float volume){
        SoundManager.SetSFXVolume(volume);
    }

    public void setMusicVolume(float volume)
    {
        SoundManager.SetMusicVolume(volume);
    }
}
