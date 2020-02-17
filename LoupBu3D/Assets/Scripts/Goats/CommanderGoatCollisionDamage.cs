using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderGoatCollisionDamage : DamageDealer
{
    private void Start()
    {
        SetDamageInfo(DataManager.instance.commanderCollisionDamage, Allegiance.ennemy);
    }
}
