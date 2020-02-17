using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatCollisionManager : MonoBehaviour
{
    [SerializeField] private GoatDamageHandler damageHandler;

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer != null)
        {
            if(damageDealer.allegiance == Allegiance.allied)
            {
                damageHandler.TakeDamage(damageDealer.damage);
            }
        }
    }
}
