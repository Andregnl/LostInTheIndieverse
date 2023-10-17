using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float health = 100f;

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
        else health -= damage;
    }

    public void Die(){
        Object.Destroy(gameObject);
    }
}
