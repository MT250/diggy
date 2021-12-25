using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeChanger : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "Master";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 5f;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(SliderValueChanged);
    }

    private void SliderValueChanged(float value)
    {
        if (value == 0f) 
            _mixer.SetFloat(_volumeParameter, -80f);
        else 
            _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
    }
}
