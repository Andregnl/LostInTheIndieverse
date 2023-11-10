using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {LEFT, RIGHT}

public class DefensiveStructure : Entity
{
	[SerializeField] protected GameObject projectile;
	[SerializeField] protected float attackDelay = 2.0f;
	[SerializeField] protected int damage = 10;
    [SerializeField] AudioSource audioSource;

	protected float currentTime = 0.0f;

    void Awake(){
        Debug.Log("Criei um Script Structure");
    }
    // Update is called once per frame
    void Update()
    {
        ExecuteDefensiveBehavior();
    }

    public void PlayShootSound()
    {
        if (audioSource == null) return;

        audioSource.Play();
    }

    public virtual void ExecuteDefensiveBehavior()
    {

    }
}
