using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : PowerUp
{

    private void Start()
    {
        StartCoroutine(Disapear());
    }
}

