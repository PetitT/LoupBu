using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderGoatDamageHandler : GoatDamageHandler
{
    protected override void Start()
    {
        health = DataManager.instance.commanderHealth;
    }
}
