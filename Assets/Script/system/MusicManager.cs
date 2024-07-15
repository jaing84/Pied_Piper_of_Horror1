using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MusicManager : MonoBehaviour
{
    public Slider volumeSlider;
    void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
        }
    }
    void OnVolumeSliderChanged(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetGlobalVolume(value);
        }
    }
  
}

