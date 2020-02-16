using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        string hit = other.tag;

        switch (hit) 
        {
            case "Goat" :
                GoatHit(other.gameObject);
                break;

            default:
                break;
        }
    }

    private void GoatHit(GameObject goat)
    {
        goat.SetActive(false);
    }
}
