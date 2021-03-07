using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI healthNum;

    public void SetMaxHealth (float health)
    {
        int healthInt = (int)health;
        slider.maxValue = health;
        slider.value = health;
        if (healthNum)
        {
            healthNum.text = healthInt.ToString();
        }

        fill.color =  gradient.Evaluate(1f);
        
    }

    public void SetHealth(float health)
    {
        int healthInt = (int)health;
        slider.value = health;

        if (healthNum)
        {
            healthNum.text = healthInt.ToString();
        }

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
