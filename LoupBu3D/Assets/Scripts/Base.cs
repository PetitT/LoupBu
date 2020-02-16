using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private GoatSpawner spawner;

    private Allegiance currentAllegiance = Allegiance.ennemy;
    private float maximumValue;
    private float currentValue;
    private float valueChangePerSecond;

    private void Start()
    {
        maximumValue = DataManager.instance.baseMaximumValue;
        currentValue = maximumValue;
        valueChangePerSecond = DataManager.instance.baseValueChangePerSecond;
    }

    private void OnTriggerStay(Collider other)
    {
        if (currentAllegiance == Allegiance.ennemy)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("hiku");
                currentValue -= valueChangePerSecond * Time.deltaTime;
                if(currentValue <= 0)
                {
                    currentAllegiance = Allegiance.allied;
                    BaseManager.instance.ChangeBaseAllegiance(this, currentAllegiance);
                    spawner.Toggle(false);
                }
            }
        }
    }

}
