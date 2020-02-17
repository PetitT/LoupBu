using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goat;
    [SerializeField] private MeshRenderer baseGround;

    private float distanceFromBounds;
    private float height;
    private float spawnFrequency;
    private float remainingSpawnFrequency;

    private bool isActive = true;

    private void Start()
    {
        height = DataManager.instance.goatHeight;
        distanceFromBounds = DataManager.instance.goatSpawnDistanceFromBounds;
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
        float randomX = UnityEngine.Random.Range(baseGround.bounds.min.x + distanceFromBounds, baseGround.bounds.max.x - distanceFromBounds);
        float randomZ = UnityEngine.Random.Range(baseGround.bounds.min.z + distanceFromBounds, baseGround.bounds.max.z - distanceFromBounds);
        Vector3 newPosition = new Vector3(randomX, height, randomZ);

        GameObject newGoat = Pool.instance.GetItemFromPool(goat, newPosition);
        GoatBehaviour.instance.UpdateList(newGoat, true);
    }

    public void Toggle(bool active)
    {
        isActive = active;
    }
}
