using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuJumper : MonoBehaviour
{
    public void JumpToMainMenu()
    {
        ManagerS manager = FindObjectOfType<ManagerS>();

        manager.SaveStats();

        SceneManager.LoadScene(0);
    }
}
