using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuJumper : MonoBehaviour
{
    public void JumpToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
