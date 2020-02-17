using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [Header("Wolf Stats")]
    public int wolfHealth;
    public float wolfMoveSpeed;
    public int scrachDamage;

    [Header("Base Stats")]
    public float baseMaximumValue;
    public float baseValueChangePerSecond;

    [Header("Small Goat")]
    public float aggroRange;
    public float goatSpeed;
    public float goatSpawnFrequency;
    public int goatsPerJobBatch;
    public float goatSpawnDistanceFromBounds;
    public float goatHeight;
    public int smallGoatHealth;
    public int goatCollisionDamage;

    [Header("Commander Goat")]
    public int commanderHealth;
    public float commanderAggroRange;
    public float commanderSpeed;
    public float valueLostPerCommanderSecond;
    public int commanderCollisionDamage;

}
