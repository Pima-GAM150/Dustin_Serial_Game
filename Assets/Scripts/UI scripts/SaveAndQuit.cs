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

    Player player;
    Boss boss;

    public void Save()
    {
        PathForSavedPlayer = Application.streamingAssetsPath + "/SavedPlayerStats.json";
        PathForSavedBoss = Application.streamingAssetsPath + "/SavedBossStats.json";

        FileStream playerFile = new FileStream(PathForSavedPlayer,FileMode.OpenOrCreate);
        FileStream bossFile = new FileStream(PathForSavedBoss, FileMode.OpenOrCreate);

        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();
        if(player!=null &&boss!= null)
        {
            player.SaveStats();
            boss.SaveStats();

            string playerJson = JsonUtility.ToJson(player.stats);
            string bossJson = JsonUtility.ToJson(boss.stats);

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

        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();

        string playerJson = File.ReadAllText(PathForSavedPlayer);
        string bossJson = File.ReadAllText(PathForSavedBoss);

        player.stats = JsonUtility.FromJson<PlayerStats>(playerJson);
        boss.stats = JsonUtility.FromJson<BossStats>(bossJson);

        player.LoadStats();
        boss.LoadStats();

        playerFile.Close();
        bossFile.Close();
    }

    public void ResetStats()
    {
        PathForInitialPlayer = Application.streamingAssetsPath + "/InitialPlayerStats.json";
        PathForInitialBoss = Application.streamingAssetsPath + "/InitialBossStats.json";

        FileStream playerFile = new FileStream(PathForInitialPlayer, FileMode.Open);
        FileStream bossFile = new FileStream(PathForInitialBoss, FileMode.Open);

        player = FindObjectOfType<Player>();
        boss = FindObjectOfType<Boss>();

        string playerJson = File.ReadAllText(PathForSavedPlayer);
        string bossJson = File.ReadAllText(PathForSavedBoss);

        player.stats = JsonUtility.FromJson<PlayerStats>(playerJson);
        boss.stats = JsonUtility.FromJson<BossStats>(bossJson);

        player.LoadStats();
        boss.LoadStats();

        playerFile.Close();
        bossFile.Close();
    }

    public void Quit()
    {
        Save();
        Application.Quit();
    }

}
