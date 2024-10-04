using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthUIsystem : MonoBehaviour
{
    public Slider healthSlider;

    public void removeHealth(float healthData)
    {
        healthSlider.value = healthData;
    }

    public void resetHealth()
    {
        healthSlider.value = 1f;
    }
}