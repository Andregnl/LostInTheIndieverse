using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBugshieldEvents : MonoBehaviour
{
    [SerializeField] private ShieldBug bug;
    [SerializeField] private float noShieldInterval;

    public void SetNewDamageInterval(){
        bug.SetDamageInterval(noShieldInterval);
    }
}
