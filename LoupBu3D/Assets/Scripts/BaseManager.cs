using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : Singleton<BaseManager>
{
    private Dictionary<Base, Allegiance> bases = new Dictionary<Base, Allegiance>();
    public Dictionary<Base, Allegiance> Bases { get => bases; private set => bases = value; }

    public event Action onAllBasesPosessed;
    public event Action onBaseAllegianceChange;

    public void AddBase(Base newBase, Allegiance newAllegiance)
    {
        Bases.Add(newBase, newAllegiance);
    }

    public void ChangeBaseAllegiance(Base currentBase, Allegiance newAllegiance)
    {
        Bases[currentBase] = newAllegiance;
        CheckBasesState();
        onBaseAllegianceChange?.Invoke();
    }

    private void CheckBasesState()
    {
        int index = 0;
        foreach (var item in Bases)
        {
            if (item.Value == Allegiance.allied)
            {
                index++;
            }
        }
        if(index == Bases.Count)
        {
            onAllBasesPosessed?.Invoke();
        }
    }
}
