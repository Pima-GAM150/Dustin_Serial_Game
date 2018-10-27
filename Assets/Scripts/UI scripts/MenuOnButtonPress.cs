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
            Time.timeScale = 0.001f;
        }
    }
    public void UnPause()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
    }

}
