using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoost : PowerUp
{
    private void Start()
    {
        StartCoroutine(Disapear());
    }

}
