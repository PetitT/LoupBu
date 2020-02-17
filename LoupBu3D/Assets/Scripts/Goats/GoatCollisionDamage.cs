using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatCollisionDamage : DamageDealer
{
    private void Start()
    {
        SetDamageInfo(DataManager.instance.goatCollisionDamage, Allegiance.ennemy);
    }
}
