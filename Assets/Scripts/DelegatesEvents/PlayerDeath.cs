using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    private Player player;


    private void Start()
    {
        player = this.GetComponent<Player>();

    }
    void Update ()
    {
        CheckForDeath();	
	}

    void CheckForDeath()
    {
        if (player.Health <= 0)
        {
            if (DeathDelegaate.OnDeathEvent != null)
            {
                DeathDelegaate.OnDeathEvent(this.GetComponent<Character>());
            }
        }
    }
}
