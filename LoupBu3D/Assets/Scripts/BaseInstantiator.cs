using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseInstantiator : Singleton<BaseInstantiator>
{
    [SerializeField] private List<Transform> basePositions;
    [SerializeField] private GameObject basePrefab;

    public void CreateBases(int numberOfBases)
    {
        for (int i = 0; i < numberOfBases; i++)
        {
            int random = UnityEngine.Random.Range(0, basePositions.Count);
            GameObject newBase = Pool.instance.GetItemFromPool(basePrefab, basePositions[random].position);
            BaseManager.instance.AddBase(newBase.GetComponent<Base>(), Allegiance.ennemy);
            basePositions.Remove(basePositions[random]);
        }
    }
}
