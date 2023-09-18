using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SoundInit : MonoBehaviour
{
    [SerializeField] private SoundAudio[] SoundAudioArr;

    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.SoundAudioArr = SoundAudioArr;
    }
}
