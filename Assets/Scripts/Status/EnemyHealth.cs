using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider sliderHealth;
    private int health;
    public event Action OnTakeDamage;
    public event Action OnDie;
    void Start()
    {
        health = maxHealth;
        sliderHealth.maxValue = maxHealth;
        sliderHealth.value = maxHealth;
    }

    public void DealDamage(int damage)
    {
        if (health <= 0) return;

        health = Mathf.Max(health - damage, 0);
        sliderHealth.value = health;
        OnTakeDamage?.Invoke();
        if (health == 0) { OnDie?.Invoke(); }
    }
}
