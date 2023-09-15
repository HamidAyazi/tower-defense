using UnityEngine;

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
    private static AudioClip GetSound(Sound sound)
    {

        foreach (var soundAudio in SoundAudioArr)
        {
            if (soundAudio.sound == sound) return soundAudio.clip;
        }
        Debug.LogError("Error: " + sound + " Can not be found!");
        return null;
    }

    /// <summary>
    /// Play a Global Audio.
    /// </summary>
    /// <param name="sound">Sound to be played.</param>
    public static void PlaySound(Sound sound)
    {
        if (SoundGameObject == null)
        {
            SoundGameObject = new GameObject("OneShotSound");
            GlobalAudioSource = SoundGameObject.AddComponent<AudioSource>();
        }
        GlobalAudioSource.volume = 1f;
        GlobalAudioSource.PlayOneShot(GetSound(sound));
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
        audioSource.clip = GetSound(sound);
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.maxDistance = 5f;
        audioSource.Play();

        Object.Destroy(PositionedSoundGameObject, audioSource.clip.length);
    }

}
