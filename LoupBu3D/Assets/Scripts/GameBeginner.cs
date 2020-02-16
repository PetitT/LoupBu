using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBeginner : Singleton<GameBeginner>
{
    private void Start()
    {
        BaseInstantiator.instance.CreateBases(3);
    }
}
