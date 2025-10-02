using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient gradient;
    public void setMaxHealth(float health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        healthSlider.fillRect.GetComponent<Image>().color = gradient.Evaluate(1f);
    }

    public void setHealth(float health)
    {
        healthSlider.value = health;
        healthSlider.fillRect.GetComponent<Image>().color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
