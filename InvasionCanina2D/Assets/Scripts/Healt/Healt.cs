using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks.Sources;
using UnityEngine;

public class Healt : MonoBehaviour
{
    public float maxHealth;

    public float percent
    {
        get { return this.currentHealth / this.maxHealth; }
    }

    protected float currentHealth;

    public bool isPlayer;

    private static int score = 0;

    protected virtual void Awake()
    {
        this.currentHealth = this.maxHealth;
    }

    public virtual void Restore(float amount)
    {
        this.currentHealth = Mathf.Clamp(this.currentHealth + amount, 0, this.maxHealth);
    }

    public virtual void Damage(float amount)
    {
        this.currentHealth = Mathf.Clamp(this.currentHealth - amount, 0, this.maxHealth);

        if (this.currentHealth == 0)
        {
            this.Die();
        }
    }

    public virtual void Die()
    {

        if (isPlayer)
        {
            score = 0;
        }
        else
        {
            score += 1;
        }
        Debug.Log("Score: " + score);
        Destroy(this.gameObject);
    }

    public float GetHealthPercent()
    {
        return currentHealth / maxHealth;
    }

    public bool RecuperarVida(float amount)
    {
        if (this.currentHealth < this.maxHealth)
        {
            this.currentHealth = Mathf.Clamp(this.currentHealth + amount, 0, this.maxHealth);
            return true;
        }

        return false;
    }
    public static int ObtenerPuntaje()
    {
        return score;
    }
}

