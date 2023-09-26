using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSettings : MonoBehaviour
{
    /// <summary>
    /// Adjust SFX volume
    /// </summary>
    /// <param name="volume">Amount of volume.</param>
    public void setSFXVolume(float volume){
        SoundManager.SetSFXVolume(volume);
    }
    /// <summary>
    /// Adjust Music volume
    /// </summary>
    /// <param name="volume">Amount of volume.</param>
    public void setMusicVolume(float volume)
    {
        SoundManager.SetMusicVolume(volume);
    }
}
