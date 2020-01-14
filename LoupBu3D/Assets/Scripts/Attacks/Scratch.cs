using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scratch : BaseAttack
{
    public override event Action finish;

    public GameObject scratch;

    public override void Attack(Action onFinish)
    {
        GameObject attackObject = Pool.instance.GetItemFromPool(scratch, Vector3.zero);
        attackObject.transform.position = WolfMovement.instance.currentDirection.position;
        attackObject.transform.LookAt(WolfMovement.instance.gameObject.transform.position);
        onFinish?.Invoke();
    }
}
