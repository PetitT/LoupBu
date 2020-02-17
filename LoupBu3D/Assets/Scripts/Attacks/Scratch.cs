using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : BaseAttack
{
    public override event Action finish;
    [SerializeField] private GameObject scratch;
    private int damage;

    private void Start()
    {
        damage = DataManager.instance.scrachDamage;
    }

    public override void Attack(Action onFinish)
    {
        GameObject attackObject = Pool.instance.GetItemFromPool(scratch, Vector3.zero);
        attackObject.GetComponent<DamageDealer>().SetDamageInfo(damage, Allegiance.allied);
        attackObject.transform.position = WolfMovement.instance.currentDirection.position;
        attackObject.transform.LookAt(WolfMovement.instance.gameObject.transform.position);
        onFinish?.Invoke();
    }
}
