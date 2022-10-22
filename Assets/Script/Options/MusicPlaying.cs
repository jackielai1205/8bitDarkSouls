//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlaying : MonoBehaviour
{
    private AudioSource AudioSource;

    public Slider volumeSlider;

    private float MusicVolume = 1f;

    public GameObject ObjectMusic;
    // Start is called before the first frame update
    void Start()
    {

        ObjectMusic = GameObject.FindWithTag("GameMusic");
        AudioSource = ObjectMusic.GetComponent<AudioSource>();

        //AudioSource.Play();
        MusicVolume = PlayerPrefs.GetFloat("volume");
        AudioSource.volume = MusicVolume;
        volumeSlider.value = MusicVolume;
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
