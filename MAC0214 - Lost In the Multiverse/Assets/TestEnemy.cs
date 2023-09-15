using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : EnemyBasics
{

    void FixedUpdate(){
        transform.Translate(Vector2.left * 10 * Time.deltaTime);
    }
    
}
