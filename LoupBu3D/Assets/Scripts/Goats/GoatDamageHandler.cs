using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatDamageHandler : MonoBehaviour, IDamageable
{
    protected int health;

    protected virtual void Start()
    {
        health = DataManager.instance.smallGoatHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
