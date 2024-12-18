using System;
using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] float periodOfHeal = 1.0f;
    [SerializeField] int amountOfAutoHeal = 1;

    Action death;
    Action alive;

    public float generalHealth { get; private set; }
    public float currentHealth { get; private set; }
    Coroutine coroutine;

    void Start()
    {
        StartCoroutine(AutoHeal());
    }

    void OnEnable()
    {
        alive?.Invoke();
    }

    IEnumerator AutoHeal()
    {
        while (true)
        {
            yield return new WaitForSeconds(periodOfHeal);
            if (currentHealth < 99)
            {
                currentHealth += amountOfAutoHeal;
            }
        }
    }

    public void SetHealth(int healthPoints)
    {
        generalHealth = healthPoints;
    }

    public void TakeDamege(int damage)
    {
        if (currentHealth - damage < 1)
        {
            currentHealth = 0;
            death?.Invoke();
        }
        else
        {
            currentHealth -= damage;
        }
    }

    public void Healing(int amountOfHealing)
    {
        if (currentHealth + amountOfHealing > generalHealth)
        {
            currentHealth = generalHealth;
        }
        else
        {
            currentHealth += amountOfHealing;
        }
    }
}
