using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(Slider))]

public class AudioManager : MonoBehaviour
{
   [SerializeField] AudioMixer mixer;
   [SerializeField] string sliderName;

    Slider slider
    {
        get { return GetComponent<Slider>(); }
    }
    void Start()
    {
        //slider.value = PlayerPrefs.GetFloat(sliderName);
        //UpdateValueOnChange(slider.value);
        slider.onValueChanged.AddListener(delegate
        {
            UpdateValueOnChange(slider.value);
        });
    }
    public void UpdateValueOnChange(float value)
    {
        if(mixer != null)
        mixer.SetFloat(sliderName, Mathf.Log(value) * 20f);        
        PlayerPrefs.SetFloat(sliderName,slider.value);
    }
}
