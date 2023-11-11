using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveTowerHealth : Health
{
    [SerializeField] ExplosiveTowerEvents exp;
    public override void TakeDamage(float damage){
        exp.Explode();
    }
}
