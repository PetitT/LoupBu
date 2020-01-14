using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawAttackBehaviour : MonoBehaviour
{
    public float lifetime;
    private float remainingLifetime;

    private void OnEnable()
    {
        remainingLifetime = lifetime;
    }

    private void Update()
    {
        remainingLifetime -= Time.deltaTime;
        if(remainingLifetime <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
