using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnButtonPress : MonoBehaviour
{
    public GameObject Menu;
    private void Update()
    {
        if(Input.GetAxis("Cancel") == 1 && !Menu.activeInHierarchy)
        {
            Menu.SetActive(true);

        }
    }
}
