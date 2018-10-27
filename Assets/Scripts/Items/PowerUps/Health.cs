using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : PowerUp
{
    private void Start()
    {
        StartCoroutine(Disapear());
    }
}
