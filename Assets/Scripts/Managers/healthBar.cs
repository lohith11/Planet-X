using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class healthBar : MonoBehaviour
{
    public static healthBar healthInstance;
    private void Awake()
    {

        if (healthInstance == null)
        {
            healthInstance = this;
        }
    }

    public Slider slider;
    Text healthText;
    public Gradient gradient;
    public Image fill;


    private void Start()
    {
        fill.color = gradient.Evaluate(1f);
        //slider.value = 500;
        healthText = GetComponentInChildren<Text>();
    }
    
    private void Update()
    {
        
    }
    public void setHealth(float health)
    {
        healthText.color = gradient.Evaluate(slider.normalizedValue);
        healthText.text = slider.value.ToString(); 
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }   

    public void setMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(1f);
    }
}
