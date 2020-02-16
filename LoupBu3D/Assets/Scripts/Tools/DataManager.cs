using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    [Header("Base Stats")]
    public float baseMaximumValue;
    public float baseValueChangePerSecond;

    [Header("Goat")]
    public float goatSpeed;
    public float goatSpawnFrequency;
    public int goatsPerJobBatch;
}
