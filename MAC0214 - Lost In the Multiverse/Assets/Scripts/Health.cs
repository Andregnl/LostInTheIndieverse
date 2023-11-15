using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 100f;
	[SerializeField] Animator animator;
	[SerializeField] Image healthbar;

    public float GetCurrentHealth(){
        return health;
    }

    public void Heal(float healing){
        float newHealth = health + healing;
        if(newHealth > maxHealth) health = maxHealth;
        else health += healing;
    }

    public void TakeDamage(float damage){
        float newHealth = health - damage;
        if(newHealth <= 0) Die();
        else
		{
			health -= damage;

			if (healthbar != null)
				healthbar.fillAmount = health / maxHealth;

			if (animator != null)
				animator.SetTrigger("TakeDamage");
		}
    }

    public void Die(){

		if (healthbar != null)
			healthbar.fillAmount = 0;

        Object.Destroy(gameObject);
    }
}
