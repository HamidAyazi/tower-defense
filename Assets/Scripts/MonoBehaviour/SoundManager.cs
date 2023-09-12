using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class SoundManager
{
    public static SoundAudio[] SoundAudioArr;
    private static GameObject SoundGameObject;
    private static AudioSource GlobalAudioSource;

    [System.Serializable]
    public class SoundAudio
    {
        public Sound sound;
        public AudioClip clip;
    }
    public static void PlaySound(Sound sound)
    {
        if (SoundGameObject == null)
        {
            SoundGameObject = new GameObject("OneShotSound");
            GlobalAudioSource = SoundGameObject.AddComponent<AudioSource>();
        }
        GlobalAudioSource.PlayOneShot(GetSound(sound));
    }
    public static void PlaySound(Sound sound, Vector3 position, string Name)
    {
        GameObject PositionedSoundGameObject = new GameObject(Name);
        PositionedSoundGameObject.transform.position = position;
        AudioSource audioSource = PositionedSoundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetSound(sound);
        audioSource.Play();

        Object.Destroy(PositionedSoundGameObject, audioSource.clip.length);
    }

    private static AudioClip GetSound(Sound sound)
    {

        foreach (var soundAudio in SoundAudioArr)
        {
            if (soundAudio.sound == sound) return soundAudio.clip;
        }
        Debug.LogError("Error: " + sound + " Can not be found!");
        return null;
    }
    
}
