using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAttack : MonoBehaviour
{
    public abstract event Action finish;

    public abstract void Attack(Action onFinish);
}
