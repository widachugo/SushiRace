using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider slider;

    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        slider.value = audioSource.volume;
    }

    void Update()
    {
        audioSource.volume = Mathf.Lerp(slider.minValue, slider.value, slider.maxValue / slider.value);
    }
}
