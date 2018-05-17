using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggles : MonoBehaviour
{

    public Slider heightSlider;
    public Text heightSliderText;

    void Start()
    {
        heightSliderText.text = heightSlider.value.ToString();
        heightSlider.onValueChanged.AddListener(ChangeValue);
        ChangeValue(heightSlider.value);
    }

    void ChangeValue(float value)
    {
        heightSliderText.text = value.ToString();
    }
}
