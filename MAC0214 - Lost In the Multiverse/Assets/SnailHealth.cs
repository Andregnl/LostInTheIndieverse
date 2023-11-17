using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailHealth : Health
{

    [SerializeField] private int shellLife = 1;

    public int GetShellLife(){
        return shellLife;
    }
    public override void TakeDamage(float damage){
        StartCoroutine(PlayTakeDamage());
        float newHealth = health - damage;
        
        if(newHealth <= 0)
        {
            healthAnimator.SetTrigger("TakeDamage");
            if(shellLife <= 0)
            {
                ExpireVisual();
            }
            shellLife -= 1;
            health -= damage;
        }
        else
        { 
            health -= damage;
        }

    }

    public void ExpireVisual()
    {
        healthAnimator.SetTrigger("Die");
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            healthAnimator.SetTrigger("Launch");
        }
    }
}
