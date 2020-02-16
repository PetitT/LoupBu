using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Burst;
using Unity.Collections;
using System;

public class GoatBehaviour : Singleton<GoatBehaviour>
{
    private float goatSpeed;
    private int goatsPerJobBatch;
    private List<GameObject> activeGoats = new List<GameObject>();
    private Transform target;

    private void Start()
    {
        goatSpeed = DataManager.instance.goatSpeed;
        goatsPerJobBatch = DataManager.instance.goatsPerJobBatch;
        target = WolfMovement.instance.gameObject.transform;
    }

    public void UpdateList(GameObject goat, bool active)
    {
        if (active)
        {
            activeGoats.Add(goat);
        }
        else
        {
            try
            {
                activeGoats.Remove(goat);
            }
            catch
            {
                Debug.Log("Goat was not on the list");
            }
        }
    }

    private void Update()
    {
        NativeArray<float3> positionArray = new NativeArray<float3>(activeGoats.Count, Allocator.TempJob);
        NativeArray<float3> directionArray = new NativeArray<float3>(activeGoats.Count, Allocator.TempJob);

        for (int i = 0; i < activeGoats.Count; i++)
        {
            positionArray[i] = activeGoats[i].transform.position;
        }

        for (int i = 0; i < activeGoats.Count; i++)
        {
            directionArray[i] = GetDirection(activeGoats[i].transform.position);
        }

        FollowWolf followWolf = new FollowWolf
        {
            speed = goatSpeed,
            deltaTime = Time.deltaTime,
            positionArray = positionArray,
            directionArray = directionArray
        };

        JobHandle jobHandle = followWolf.Schedule(activeGoats.Count, goatsPerJobBatch);
        jobHandle.Complete();

        for (int i = 0; i < activeGoats.Count; i++)
        {
            activeGoats[i].transform.position = positionArray[i];
        }

        positionArray.Dispose();
        directionArray.Dispose();

    }

    private float3 GetDirection(Vector3 position)
    {
        Vector3 direction = target.position - position;
        float distance = direction.magnitude;
        Vector3 normalizedDirection = direction / distance;
        return (float3)normalizedDirection;
    }
}

[BurstCompile]
public struct FollowWolf : IJobParallelFor
{
    public NativeArray<float3> positionArray;
    public NativeArray<float3> directionArray;
    public float deltaTime;
    public float speed;

    public void Execute(int index)
    {
        positionArray[index] += directionArray[index] * speed * deltaTime;   
    }
}
