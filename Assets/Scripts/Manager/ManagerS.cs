using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerS : MonoBehaviour
{
    public static ManagerS Manager = null;
    /*[HideInInspector]*/public PlayerStats PlayerData;
    [HideInInspector]public BossStats BossData;

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

    public void SaveStats()
    {
        Player player = FindObjectOfType<Player>();
        Boss boss = FindObjectOfType<Boss>();


        if (player != null && boss != null)
        {
            player.SaveStats();
            boss.SaveStats();
            PlayerData = player.stats;
            BossData = boss.stats;
        }
    }

    public void LoadStats()
    {
        Player player = FindObjectOfType<Player>();
        Boss boss = FindObjectOfType<Boss>();

        if (player != null && boss != null)
        {
            player.stats = PlayerData;
            boss.stats = BossData;

            player.LoadStats();
            boss.LoadStats();
        }
    }

    

}
