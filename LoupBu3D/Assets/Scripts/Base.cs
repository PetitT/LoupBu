using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] private GoatSpawner spawner;

    private Allegiance currentAllegiance = Allegiance.ennemy;
    private float maximumValue;
    private float currentValue;
    private float valueGainPerSecond;
    private float valueLostPerCommanderSecond;

    private void Start()
    {
        maximumValue = DataManager.instance.baseMaximumValue;
        valueGainPerSecond = DataManager.instance.baseValueChangePerSecond;
        valueLostPerCommanderSecond = DataManager.instance.valueLostPerCommanderSecond;
        currentValue = maximumValue;
    }


    //to remove
    private void Update()
    {
        if (currentAllegiance == Allegiance.allied)
            GetComponentInChildren<MeshRenderer>().material.color = Color.blue;

        if (currentAllegiance == Allegiance.ennemy)
            GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(TagsManager.instance.Player))
        {
            currentValue -= valueGainPerSecond * Time.deltaTime;
            if (currentValue <= 0)
            {
                currentValue = 0;
                if (currentAllegiance == Allegiance.ennemy)
                {
                    currentAllegiance = Allegiance.allied;
                    BaseManager.instance.ChangeBaseAllegiance(this, currentAllegiance);
                    spawner.Toggle(false);
                }
            }
        }

        if (other.CompareTag(TagsManager.instance.CommanderGoat))
        {
            currentValue += valueLostPerCommanderSecond * Time.deltaTime;
            if (currentValue >= maximumValue)
            {
                currentValue = maximumValue;
                if(currentAllegiance == Allegiance.allied)
                {
                    currentAllegiance = Allegiance.ennemy;
                    BaseManager.instance.ChangeBaseAllegiance(this, currentAllegiance);
                    spawner.Toggle(true);
                }
            }
        }
    }

}
