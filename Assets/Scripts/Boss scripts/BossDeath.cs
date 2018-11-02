using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDeath : MonoBehaviour
{

    private Boss boss;


    private void Start()
    {
        boss = FindObjectOfType<Boss>();

    }
    void Update()
    {
        CheckForDeath();
    }

    void CheckForDeath()
    {
        if (boss.Health <= 0)
        {
            SceneManager.LoadScene("WinningEnding");
        }
    }
}
