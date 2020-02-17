using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BigGoatBehaviour : MonoBehaviour
{
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private LayerMask playerLayer;
    private float speed;
    private float aggroRange;
    private Transform destination;
    private Vector3 previousPosition;
    private bool isAggro = false;

    private void Start()
    {
        BaseManager.instance.onBaseAllegianceChange += BaseAllegianceChangeHandler;
        aggroRange = DataManager.instance.commanderAggroRange;
        speed = DataManager.instance.commanderSpeed;
        previousPosition = transform.position;
        nav.speed = speed;
        GetNewDestination();
    }

    private void OnDisable()
    {
        BaseManager.instance.onBaseAllegianceChange -= BaseAllegianceChangeHandler;
    }

    private void Update()
    {
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        CheckPlayer();
        CheckDirection();
    }

    private void CheckPlayer()
    {

        if (Vector3.Distance(transform.position, WolfMovement.instance.transform.position) < aggroRange)
        {
            nav.SetDestination(WolfMovement.instance.transform.position);
            isAggro = true;
        }

        if (isAggro)
        {
            if (Vector3.Distance(transform.position, WolfMovement.instance.transform.position) > aggroRange)
            {
                GetNewDestination();
                isAggro = false;
            }
        }
    }

    private void CheckDirection()
    {
        Vector3 currentPosition = gameObject.transform.position;

        if (currentPosition.x > previousPosition.x)
        {
            sprite.flipX = false;
        }
        else if (currentPosition.x < previousPosition.x)
        {
            sprite.flipX = true;
        }

        previousPosition = currentPosition;
    }

    private void BaseAllegianceChangeHandler()
    {
        GetNewDestination();
    }

    private void GetNewDestination()
    {
        List<Base> targetBases = new List<Base>();
        foreach (var item in BaseManager.instance.Bases)
        {
            if (item.Value == Allegiance.allied)
            {
                targetBases.Add(item.Key);
            }
        }

        if (targetBases.Count == 0)
        {
            nav.SetDestination(transform.position);
        }
        else
        {
            int random = UnityEngine.Random.Range(0, targetBases.Count - 1);
            nav.SetDestination(targetBases[random].transform.position);
        }
    }

}
