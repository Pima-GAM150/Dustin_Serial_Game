using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void ResetGame()
    {
        SaveAndQuit sq = FindObjectOfType<SaveAndQuit>();

        sq.ResetStats();
    }
}
