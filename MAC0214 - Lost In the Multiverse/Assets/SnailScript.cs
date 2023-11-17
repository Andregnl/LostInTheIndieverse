using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailScript : EnemyBasics
{
	float currentTime = 0.0f;
    [SerializeField] SnailHealth snail;
    void Update(){
        Walk();
        DetectTarget();

		if (currentTarget == null) return;

		currentTime += Time.deltaTime;
		if (currentTime > damageInterval)
		{
                            Debug.Log("Entrou IF");


            if(snail.GetCurrentHealth() <= 0)
            {
                Debug.Log("Entrou aqui");
			    animator.SetTrigger("HitAndDie");
            }
            else{
                StrikeCurrentTarget();
            }
			currentTime = 0.0f;
		}
    }
}
