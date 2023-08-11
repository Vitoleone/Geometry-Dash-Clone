using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = gameObject.GetComponent<Slider>();
    }

    private void Start()
    {
        _slider.onValueChanged.AddListener(vol =>AudioManager.Instance.ChangeVolume(vol));
    }
}
