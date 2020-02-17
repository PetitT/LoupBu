using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfMovement : Singleton<WolfMovement>
{
    private float moveSpeed;

    [Header("Animation")]
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;

    [Header("Directions")]
    [SerializeField] private Transform top;
    [SerializeField] private Transform topRight;
    [SerializeField] private Transform right;
    [SerializeField] private Transform bottomRight;
    [SerializeField] private Transform bottom;
    [SerializeField] private Transform bottomLeft;
    [SerializeField] private Transform left;
    [SerializeField] private Transform topLeft;

    public Transform currentDirection { get; private set; }

    private float XMove;
    private float ZMove;

    private bool isMoving;
    private bool isFront;  

    private void Start()
    {
        currentDirection = bottom;
        moveSpeed = DataManager.instance.wolfMoveSpeed;
    }

    void Update()
    {
        Move();
        Animate();
        CheckDirection();
    }

    private void Move()
    {
        XMove = Input.GetAxis("Horizontal");
        ZMove = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(XMove, 0, ZMove).normalized;

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

    private void OnDrawGizmos()
    {
        if (currentDirection)
            Gizmos.DrawLine(transform.position, currentDirection.position);
    }
}
