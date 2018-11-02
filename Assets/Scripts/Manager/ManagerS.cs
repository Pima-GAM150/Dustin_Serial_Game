using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerS : MonoBehaviour
{
    public static ManagerS Manager = null;
    /*[HideInInspector]*/public PlayerStats PlayerData;
    /*[HideInInspector]*/public BossStats BossData;

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
        


        if (Player.PlayerS != null && Boss.BossS != null)
        {
            Player.PlayerS.SaveStats();
            Boss.BossS.SaveStats();
            PlayerData = Player.PlayerS.stats;
            BossData = Boss.BossS.stats;
        }
    }

    public void LoadStats()
    {
        
        if ( Player.PlayerS != null && Boss.BossS != null)
        {
            Player.PlayerS.stats = PlayerData;
            Boss.BossS.stats = BossData;

            Player.PlayerS.LoadStats();
            Boss.BossS.LoadStats();
        }
    }

    

}
