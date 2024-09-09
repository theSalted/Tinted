using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoop2Files : MonoBehaviour
{

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip musicStart;
    void Start()
    {
        musicSource.PlayOneShot(musicStart);
	    musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
    }

}
