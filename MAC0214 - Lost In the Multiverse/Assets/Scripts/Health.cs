using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected float health = 100f;
	[SerializeField] protected Animator healthAnimator;
	[SerializeField] Image healthbar;

    public float GetCurrentHealth(){
        return health;
    }

    public void Heal(float healing){
        float newHealth = health + healing;
        if(newHealth > maxHealth) health = maxHealth;
        else health += healing;
    }

    public virtual void TakeDamage(float damage){
        float newHealth = health - damage;
        if(newHealth <= 0) Die();
        else
		{
			health -= damage;

			if (healthbar != null)
				healthbar.fillAmount = health / maxHealth;

			if (healthAnimator != null)
				healthAnimator.SetTrigger("TakeDamage");
		}
    }

    public virtual void Die(){

		if (healthbar != null)
			healthbar.fillAmount = 0;

        Object.Destroy(gameObject);
    }
}
