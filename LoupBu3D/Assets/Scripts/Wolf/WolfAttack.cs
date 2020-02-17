using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WolfAttack : MonoBehaviour
{
    [Header("Attacks")]
    [SerializeField] private List<BaseAttack> attacks;

    public event Action onFinish;

    private bool canAttack = true;

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canAttack = false;
            attacks[0].Attack(AttackComplete);
        }
    }

    private void AttackComplete()
    {
        canAttack = true;
    }
}
