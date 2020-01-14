using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed;

    [Header("Animation")]
    public Animator anim;
    public SpriteRenderer sprite;

    [Header("Attacks")]
    public List<BaseAttack> attacks;

    [Header("Directions")]
    public Transform top;
    public Transform topRight;
    public Transform right;
    public Transform bottomRight;
    public Transform bottom;
    public Transform bottomLeft;
    public Transform left;
    public Transform topLeft;

    public event Action onFinish;

    public static WolfMovement instance;

    [HideInInspector] public Transform currentDirection;

    private float XMove;
    private float ZMove;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isFront;
    private bool canAttack = true;

    private void Awake()
    {
        if (instance)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        currentDirection = bottom;
    }

    void Update()
    {
        Move();
        Animate();
        CheckDirection();
        Attack();
    }

    private void Move()
    {
        XMove = Input.GetAxis("Horizontal");
        ZMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(XMove, 0, ZMove);

        gameObject.transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    private void CheckDirection()
    {
        if (isMoving)
        {
            if (XMove > 0 && ZMove > 0)
                currentDirection = topRight;
            else if (XMove > 0 && ZMove == 0)
                currentDirection = right;
            else if (XMove > 0 && ZMove < 0)
                currentDirection = bottomRight;
            else if (XMove == 0 && ZMove < 0)
                currentDirection = bottom;
            else if (XMove < 0 && ZMove < 0)
                currentDirection = bottomLeft;
            else if (XMove < 0 && ZMove == 0)
                currentDirection = left;
            else if (XMove < 0 && ZMove > 0)
                currentDirection = topLeft;
            else if (XMove == 0 && ZMove > 0)
                currentDirection = top;
        }
    }

    private void Animate()
    {
        if (XMove != 0 || ZMove != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (XMove < 0)
        {
            sprite.flipX = false;
        }
        else if (XMove > 0)
        {
            sprite.flipX = true;
        }

        if (ZMove > 0)
        {
            isFront = false;
        }
        else if (ZMove < 0)
        {
            isFront = true;
        }

        anim.SetBool("isFront", isFront);
        anim.SetBool("isMoving", isMoving);
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

    private void OnDrawGizmos()
    {
        if (currentDirection)
            Gizmos.DrawLine(transform.position, currentDirection.position);
    }
}
