using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 100f;
	[SerializeField] private bool playDestroyedParticles;
	[SerializeField] private GameObject bloodParticles;
	[SerializeField] private Animator animator;

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
			animator.SetTrigger("TakeDamage");
		}
    }

    public void Die(){
        if (playDestroyedParticles)
        {
            Instantiate(bloodParticles, transform.position, transform.rotation);
        }

        Object.Destroy(gameObject);
    }
}
