using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator AttackAnimation;
    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(player.CardDeck)
            {
                AttackAnimation.SetTrigger("CardThrow");
            }
            else
            {
                AttackAnimation.SetTrigger("Melee");
            }
        }
    }
}
