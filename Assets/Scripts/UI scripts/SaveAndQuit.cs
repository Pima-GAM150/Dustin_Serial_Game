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
        PathForSavedPlayer = Application.streamingAssetsPath + "/SavedPlayerStats.json";
        PathForSavedBoss = Application.streamingAssetsPath + "/SavedBossStats.json";

        FileStream playerFile = new FileStream(PathForSavedPlayer,FileMode.OpenOrCreate,FileAccess.ReadWrite);
        FileStream bossFile = new FileStream(PathForSavedBoss, FileMode.OpenOrCreate, FileAccess.ReadWrite);

        Manager= FindObjectOfType<ManagerS>();

        if(Manager!=null)
        {
            Manager.SaveStats();

            string playerJson = JsonUtility.ToJson(Manager.PlayerData);
            string bossJson = JsonUtility.ToJson(Manager.BossData);

            File.WriteAllText(PathForSavedPlayer, playerJson);
            File.WriteAllText(PathForSavedBoss, bossJson);
        }

        playerFile.Close();
        bossFile.Close();

    }

    public void Load()
    {
        PathForSavedPlayer = Application.streamingAssetsPath + "/SavedPlayerStats.json";
        PathForSavedBoss = Application.streamingAssetsPath + "/SavedBossStats.json";

        FileStream playerFile = new FileStream(PathForSavedPlayer, FileMode.Open);
        FileStream bossFile = new FileStream(PathForSavedBoss, FileMode.Open);

        Manager = FindObjectOfType<ManagerS>();

        string playerJson = File.ReadAllText(PathForSavedPlayer);
        string bossJson = File.ReadAllText(PathForSavedBoss);

        Manager.PlayerData = JsonUtility.FromJson<PlayerStats>(playerJson);
        Manager.BossData = JsonUtility.FromJson<BossStats>(bossJson);

        Manager.LoadStats();

        playerFile.Close();
        bossFile.Close();
    }

    public void ResetStats()
    {
        PathForInitialPlayer = Application.streamingAssetsPath + "/InitialPlayerStats.json";
        PathForInitialBoss = Application.streamingAssetsPath + "/InitialBossStats.json";

        FileStream playerFile = new FileStream(PathForInitialPlayer, FileMode.Open);
        FileStream bossFile = new FileStream(PathForInitialBoss, FileMode.Open);

        Manager = FindObjectOfType<ManagerS>();

        string playerJson = File.ReadAllText(PathForSavedPlayer);
        string bossJson = File.ReadAllText(PathForSavedBoss);

        Manager.PlayerData = JsonUtility.FromJson<PlayerStats>(playerJson);
        Manager.BossData = JsonUtility.FromJson<BossStats>(bossJson);

        Manager.LoadStats();

        playerFile.Close();
        bossFile.Close();
    }

    public void Quit()
    {
        Save();
        Application.Quit();
    }

}
