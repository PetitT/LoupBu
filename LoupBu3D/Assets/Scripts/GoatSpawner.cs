using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatSpawner : MonoBehaviour
{
    public GameObject goat;
    public List<Transform> spawnPos;

    private float spawnFrequency;
    private float remainingSpawnFrequency;

    private bool isActive = true;

    private void Start()
    {
        spawnFrequency = DataManager.instance.goatSpawnFrequency;
        remainingSpawnFrequency = spawnFrequency;
    }

    private void Update()
    {
        if (isActive)
        {
            remainingSpawnFrequency -= Time.deltaTime;
            if (remainingSpawnFrequency <= 0)
            {
                SpawnNewGoat();
                remainingSpawnFrequency = spawnFrequency;
            }
        }
    }

    private void SpawnNewGoat()
    {
        int random = UnityEngine.Random.Range(0, spawnPos.Count);
        GameObject newGoat = Pool.instance.GetItemFromPool(goat, spawnPos[random].position);
        GoatBehaviour.instance.UpdateList(newGoat, true);
    }

    public void Toggle(bool active)
    {
        isActive = active;
    }
}
