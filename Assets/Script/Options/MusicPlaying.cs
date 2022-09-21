//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlaying : MonoBehaviour
{

    // public AudioSource AudioSource;

    // public float musicVolume = 1f;

    // //public Slider VolumeSlider;

    // public Slider slider;

    // public TextMeshProUGUI numberText;

    // void Start()
    // {
    //     AudioSource.Play();
    //     slider = GetComponent<Slider>();
    //     SetNumberText(slider.value);
    // }

    // void Update() 
    // {
    //     AudioSource.volume = musicVolume;
        
    // }

    // public void updateVolume(float volume) 
    // {
        
    //     musicVolume = volume;
    //     SetNumberText(slider.value);
    // }

    // public void SetNumberText(float value) {
    //     //float roundValue = Math.Round((float)value, 2);
    //     //numberText.text = roundValue.ToString();
    //     //numberText.text = Math.Round((decimal)value, 2).ToString();
    //     numberText.text = value.ToString();
    // }

    public AudioSource AudioSource;

    public Slider VolumeSlider;

    private float MusicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
        //MusicVolume = TextSlider.GetComponent<Slider>();
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        VolumeSlider.value = MusicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("volume", MusicVolume);
    }

    public void VolumeUpdate(float volume) 
    {
        MusicVolume = volume;
    }
}
