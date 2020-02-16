using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : Singleton<BaseManager>
{
    private Dictionary<Base, Allegiance> bases = new Dictionary<Base, Allegiance>();

    public event Action onAllBasesPosessed;

    public void AddBase(Base newBase, Allegiance newAllegiance)
    {
        bases.Add(newBase, newAllegiance);
    }

    public void ChangeBaseAllegiance(Base currentBase, Allegiance newAllegiance)
    {
        bases[currentBase] = newAllegiance;
        CheckBasesState();
    }

    private void CheckBasesState()
    {
        int index = 0;
        foreach (var item in bases)
        {
            if (item.Value == Allegiance.allied)
            {
                index++;
            }
        }
        if(index == bases.Count)
        {
            onAllBasesPosessed?.Invoke();
        }
    }
}
