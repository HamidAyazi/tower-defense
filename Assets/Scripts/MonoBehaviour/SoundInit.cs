using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

public class SoundInit : MonoBehaviour
{
    [SerializeField] private SoundAudio[] SFXArr;
    [SerializeField] private SoundAudio[] MusicArr;

    // Start is called before the first frame update
    private void Start()
    {
        SoundManager.SFXArr = SFXArr;
        SoundManager.MusicArr = MusicArr;
    }
}
