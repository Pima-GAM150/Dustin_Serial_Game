using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathListener : MonoBehaviour
{
    private void OnEnable()
    {
        DeathDelegaate.OnDeathEvent += Death;
    }
    private void OnDisable()
    {
        DeathDelegaate.OnDeathEvent -= Death;
    }

    private void Death(Character character)
    {
        if(character.tag == "Boss")
        {
            SceneManager.LoadScene("WinningEnding");
        }

        if(character.tag == "Player")
        {
            SceneManager.LoadScene("DeathEnding");
        }
    }

}
