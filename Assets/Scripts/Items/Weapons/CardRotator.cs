using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRotator : MonoBehaviour {

    public float RotationSpeed = 5;

    private void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed);
    }
}
