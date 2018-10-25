using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerS : MonoBehaviour
{
    public static ManagerS Manager = null;

    private void Awake()
    {
        if (Manager == null)
        {
            Manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Manager != this)
        {
            Destroy(gameObject);
        }


    }

}
