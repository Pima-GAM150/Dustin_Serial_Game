﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    
  /*  void LoadGame()
    {
        SaveAndQuit loader = FindObjectOfType<SaveAndQuit>();
        Manager mgr = FindObjectOfType<Manager>();

        loader.Load();

    }
  */
    public void StartGame()
    {
       // LoadGame();
        SceneManager.LoadScene(1);
    }
}