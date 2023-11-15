using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBugHealth : Health
{

    [SerializeField] private int shieldHits = 3;
    [SerializeField] private Animator animator;
    public override void TakeDamage(float damage){
        
        float newHealth = health - damage;
        
        if (shieldHits <= 0)
        {
            animator.SetTrigger("attack");
            if(newHealth <= 0) Die();
            else health -= damage;
        
        }
        else{
            shieldHits -= 1;
        }
    }
}
