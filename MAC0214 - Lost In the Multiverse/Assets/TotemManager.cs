using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemManager : DefensiveStructure
{
    [SerializeField] private TotemScript t1;
    [SerializeField] private TotemScript t2;

    void Start()
    {

        t1.SetDirection(GetDirection());
        t1.SetRow(GetRow());
        t2.SetDirection(GetDirection());
        t2.SetRow(GetRow());
    }
}
