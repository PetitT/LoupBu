using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoatManager : MonoBehaviour
{
    public GameObject goat;
    public List<Transform> spawnPos;

    public int numberOfGoatsAtStart;

    private void Start()
    {
        for (int i = 0; i < numberOfGoatsAtStart; i++)
        {
            int random = UnityEngine.Random.Range(0, spawnPos.Count);
            GameObject newGoat = Pool.instance.GetItemFromPool(goat, spawnPos[random].position);
            GoatBehaviour.instance.UpdateList(newGoat, true);
        }
    }
}
