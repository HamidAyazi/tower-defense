using Unity.VisualScripting;
using UnityEngine;

public static class SoundManager
{
    public static SoundAudio[] SFXArr;
    public static SoundAudio[] MusicArr;
    private static GameObject SFXGameObject;
    private static GameObject MusicGameObject;
    private static AudioSource GlobalSFXAudioSource;
    private static AudioSource GlobalMusicAudioSource;
    private static float SFXVolume = 1f;
    private static float MusicVolume = 1f;

    [System.Serializable]
    public class SoundAudio
    {
        public Sound sound;
        public AudioClip clip;
    }

    private static AudioClip GetSFX(Sound sound)
    {
        foreach (SoundAudio soundAudio in SFXArr)
        {
            if (soundAudio.sound == sound) return soundAudio.clip;
        }
        Debug.LogError("Error: " + sound + " Can not be found!");
        return null;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="SceneID"></param>
    public static void PlayBackgroundMusic(int SceneID)
    {
        if (MusicGameObject == null)
        {
            MusicGameObject = new GameObject("OneShotSound");
            GlobalMusicAudioSource = MusicGameObject.AddComponent<AudioSource>();
            GlobalMusicAudioSource.volume = MusicVolume;
            GlobalMusicAudioSource.loop = true;
        }
        if (SceneID == 0)
        {
            GlobalMusicAudioSource.clip = MusicArr[0].clip;
            GlobalMusicAudioSource.Play();
        }
        else
        {
            int MusicIndex = (int) (Random.value * 3);
            GlobalMusicAudioSource.clip = MusicArr[MusicIndex].clip;
            GlobalMusicAudioSource.Play();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static void StopBackgroundMusic()
    {
        GlobalMusicAudioSource.Stop();
    }

    /// <summary>
    /// Play a Global Audio.
    /// </summary>
    /// <param name="sound">Sound to be played.</param>
    public static void PlaySound(Sound sound)
    {
        if (SFXGameObject == null)
        {
            SFXGameObject = new GameObject("OneShotSound");
            GlobalSFXAudioSource = SFXGameObject.AddComponent<AudioSource>();
        }
        GlobalSFXAudioSource.volume = SFXVolume;
        GlobalSFXAudioSource.PlayOneShot(GetSFX(sound));
    }

    /// <summary>
    /// Play and Audio at a specific position of the game.
    /// </summary>
    /// <param name="sound">Sound to be Played.</param>
    /// <param name="position">Position of the sound.</param>
    /// <param name="Name">Name for created <c>GameObject</c>.</param>
    public static void PlaySound(Sound sound, Vector3 position, string Name)
    {
        GameObject PositionedSoundGameObject = new GameObject(Name);
        PositionedSoundGameObject.transform.position = position;
        AudioSource audioSource = PositionedSoundGameObject.AddComponent<AudioSource>();
        audioSource.clip = GetSFX(sound);
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.maxDistance = 5f;
        audioSource.volume = MusicVolume;
        audioSource.Play();

        Object.Destroy(PositionedSoundGameObject, audioSource.clip.length);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="volume"></param>
    public static void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
        if (GlobalSFXAudioSource != null)
        {
            GlobalSFXAudioSource.volume = volume;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="volume"></param>
    public static void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
        if (GlobalMusicAudioSource != null)
        {
            GlobalMusicAudioSource.volume = volume;
        }
    }

}
