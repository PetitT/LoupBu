using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage { get; private set; }
    public Allegiance allegiance { get; private set; }

    public void SetDamageInfo(int attackDamage, Allegiance attackAllegiance)
    {
        damage = attackDamage;
        allegiance = attackAllegiance;
    }
}
