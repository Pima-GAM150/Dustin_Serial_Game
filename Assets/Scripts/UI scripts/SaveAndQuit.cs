using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveAndQuit : MonoBehaviour
{
    private string PathForInitialPlayer;
    private string PathForInitialBoss;
    private string PathForSavedPlayer;
    private string PathForSavedBoss;

    ManagerS Manager;

    public void Save()
    {
        Manager = FindObjectOfType<ManagerS>();
        string bossJson = string.Empty, playerJson = string.Empty;
        if(Manager!=null)
        {
            Manager.SaveStats();

            playerJson = JsonUtility.ToJson(Manager.PlayerData);
            bossJson = JsonUtility.ToJson(Manager.BossData);
        }

        PathForSavedPlayer = Application.streamingAssetsPath + "/SavedPlayerStats.json";
        PathForSavedBoss = Application.streamingAssetsPath + "/SavedBossStats.json";
        

        File.WriteAllText(PathForSavedPlayer, playerJson);
        File.WriteAllText(PathForSavedBoss,bossJson);
        
    }

    public void Load()
    {
        PathForSavedPlayer = Application.streamingAssetsPath + "/SavedPlayerStats.json";
        PathForSavedBoss = Application.streamingAssetsPath + "/SavedBossStats.json";
        
        Manager = FindObjectOfType<ManagerS>();

        string playerJson = File.ReadAllText(PathForSavedPlayer);
        string bossJson = File.ReadAllText(PathForSavedBoss);

        Manager.PlayerData = JsonUtility.FromJson<PlayerStats>(playerJson);
        Manager.BossData = JsonUtility.FromJson<BossStats>(bossJson);


        
    }

    public void ResetStats()
    {
        PathForInitialPlayer = Application.streamingAssetsPath + "/InitialPlayerStats.json";
        PathForInitialBoss = Application.streamingAssetsPath + "/InitialBossStats.json";
        

        Manager = FindObjectOfType<ManagerS>();

        string playerJson = File.ReadAllText(PathForInitialPlayer);
        string bossJson = File.ReadAllText(PathForInitialBoss);

        Manager.PlayerData = JsonUtility.FromJson<PlayerStats>(playerJson);
        Manager.BossData = JsonUtility.FromJson<BossStats>(bossJson);

        Manager.LoadStats();
    }

    public void Quit()
    {
        Save();
        Application.Quit();
    }

}
