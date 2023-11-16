using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotemHealth : Health
{
    [SerializeField] Animator t2;
    bool triggered = false;
    bool triggered2 = false;

    public override void TakeDamage(float damage){
        float newHealth = health - damage;
        if(newHealth <= 0) Die();
        else
		{
			health -= damage;

			if (health <= maxHealth/2)
            {
                if(healthAnimator != null && !triggered){
				    healthAnimator.SetTrigger("DestroyT1");
                    triggered = true;
                }
            }
				
		}
    }

    public override void Die()
    {
        if(!triggered2)
            t2.SetTrigger("DestroyT2");
        triggered2 = true;
    }

}
