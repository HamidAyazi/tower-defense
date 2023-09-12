using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public SoundAudio[] SoundAudioArr;
    GameObject SoundGameObject;
    AudioSource audioSource;

    [System.Serializable]
    public class SoundAudio
    {
        public Sound sound;
        public AudioClip clip;
    }
    public void PlaySound(Sound sound)
    {
        if (SoundGameObject == null)
        {
            SoundGameObject = new GameObject("OneShotSound");
            audioSource = SoundGameObject.AddComponent<AudioSource>();
        }
        audioSource.PlayOneShot(GetSound(sound));
    }
    public void PlaySound(Sound sound, Vector3 position)
    {
        GameObject PositionedSoundGameObject = new GameObject("PositionedSound");
        PositionedSoundGameObject.transform.position = position;
        AudioSource audioSource = SoundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetSound(sound);
        audioSource.Play();

        Object.Destroy(SoundGameObject, audioSource.clip.length);
    }

    private AudioClip GetSound(Sound sound)
    {
        foreach (var soundAudio in SoundAudioArr)
        {
            if (soundAudio.sound == sound) return soundAudio.clip;
        }
        Debug.LogError("Error: " + sound + " Can not be found!");
        return null;
    }
    
}
