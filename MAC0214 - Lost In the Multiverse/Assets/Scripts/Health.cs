using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Health : MonoBehaviour
{

    [SerializeField] protected float maxHealth = 100f;
    [SerializeField] protected float health = 100f;
	[SerializeField] protected Animator healthAnimator;
    [SerializeField] protected SpriteRenderer sp;
	[SerializeField] Image healthbar;
    [SerializeField] protected Material _flash;
    private Material originalMaterial;

    void Start(){
        //_flash = Resources.Load("Flash", typeof(Material)) as Material;
        originalMaterial = sp.material;
    }
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
            else{
                StartCoroutine(PlayTakeDamage());
            }
		}
    }

    public virtual void Die(){

		if (healthbar != null)
			healthbar.fillAmount = 0;

        Object.Destroy(gameObject);
    }

        public IEnumerator PlayTakeDamage()
    {
        if(sp != null)
            sp.material = _flash;
        float interval = 0.1f;

        yield return new WaitForSeconds(interval / 2);
        
        if(sp != null)
            sp.material = originalMaterial;

        yield break;
    }

}
