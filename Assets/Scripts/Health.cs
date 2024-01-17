using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Health : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    public void TakeDamage(int amount)
    {
        //play damage sound
        CurrentHealth -= amount;
        healthBar.SetHealth(CurrentHealth);

        if(IsDead())
        {
            Death();
        }
    }

    public void Heal(int amount)
    {
        //play heal sound
        CurrentHealth += amount;
        healthBar.SetHealth(CurrentHealth);

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    bool IsDead()
    {
        if (CurrentHealth <= 0)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }

    void Death()
    {

    }

}
