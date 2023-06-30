using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMasterVolume : MonoBehaviour
{
    [Header("Slider")]
    [SerializeField] private Slider[] _VolumSlider;
    [Range(0.0001f, 1)] [SerializeField] private float _initialMasterVol = .25f;

    private void Start()
    {
        _VolumSlider[0].value = _initialMasterVol;
        AudioManager.instance.SetMasterVolume(_initialMasterVol);
    }

}
