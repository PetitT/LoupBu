using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfCollisionManager : Singleton<WolfCollisionManager>
{
    public event Action<int> onDamageTaken;

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            if(damageDealer.allegiance == Allegiance.ennemy)
            {
                onDamageTaken?.Invoke(damageDealer.damage);
            }
        }
    }
}
