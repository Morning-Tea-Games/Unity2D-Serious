using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer; 

    public Slider volumeSlider; 

    public string volumeParameter = "Volume"; 

    void Start()
    {
        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    public void SetVolume(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * 20);
    }
}
