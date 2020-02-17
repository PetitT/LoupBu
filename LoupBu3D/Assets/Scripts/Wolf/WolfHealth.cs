using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfHealth : MonoBehaviour, IDamageable
{
    public event Action onDeath;

    private int health;

    private void Start()
    {
        WolfCollisionManager.instance.onDamageTaken += DamageTakenHandler;
        health = DataManager.instance.wolfHealth;
    }

    private void OnDisable()
    {
        WolfCollisionManager.instance.onDamageTaken -= DamageTakenHandler;
    }

    private void DamageTakenHandler(int damage)
    {
        TakeDamage(damage);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            onDeath?.Invoke();
            Debug.Log("Wolf is dead");
        }
    }


}
