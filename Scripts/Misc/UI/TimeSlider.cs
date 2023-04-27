using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _fillImg;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private TextMeshProUGUI _timeText;
    public void SetSlider(float time)
    {
        _slider.maxValue= time;
        UpdateSlider(time);
    }
    public void UpdateSlider(float time)
    {
        _slider.value = time;
        _fillImg.color = _gradient.Evaluate(Mathf.Clamp(_slider.value / _slider.maxValue, 0, 1));
        _timeText.text = StringConverter.ConvertToFormat(time);
    }
}