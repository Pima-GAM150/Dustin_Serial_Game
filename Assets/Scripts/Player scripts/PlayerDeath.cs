using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private Player player;


    private void Start()
    {
        player = FindObjectOfType<Player>();

    }
    void Update ()
    {
        CheckForDeath();	
	}

    void CheckForDeath()
    {
        if(player.Health <= 0)
        {
            SceneManager.LoadScene("DeathEnding");
        }
    }
}
