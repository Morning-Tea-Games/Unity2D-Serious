using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider volumeSlider;

    public string volumeParameter;
    public string playerPrefsKey = "volume";


    void Start()
    {
        if (PlayerPrefs.HasKey(playerPrefsKey))
        {
            float savedLinear = PlayerPrefs.GetFloat(playerPrefsKey);
            volumeSlider.value = savedLinear;
            SetVolume(savedLinear);
        }
        else
        {
            volumeSlider.value = 0.8f;
            SetVolume(0.8f);
        }
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }


    public void SetVolume(float value)
    {
        float dB = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
        mixer.SetFloat(volumeParameter, dB);

        PlayerPrefs.SetFloat(playerPrefsKey, value);
    }
}
