using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : PersistenSingleton<AudioManager>
{
    [SerializeField] AudioSource sFXPlayer;
    const float MIN_PITCH = 0.9f;
    const float MAX_PITCH = 1.1f;

    private float globalVolume = 1.0f;
    public void SetGlobalVolume(float volume)
    {
        globalVolume = volume;
    }
    //UI  audio
    public void PlaySFX(AudioData audioData) 
    {
        sFXPlayer.PlayOneShot(audioData.audioClip, audioData.volume * globalVolume);
    }

    public void PlayRandomSFX(AudioData audioData) 
    {
        sFXPlayer.pitch = Random.Range(MIN_PITCH,MAX_PITCH);
        PlaySFX(audioData);
    }

    public void PlayRandomSFX(AudioData[] audioDatas) 
    {
        PlayRandomSFX(audioDatas[Random.Range(0, audioDatas.Length)]);
    }
}

[System.Serializable] public class AudioData
{

    public AudioClip audioClip;
    public float volume;
}
