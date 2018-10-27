using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardThrower : MonoBehaviour {

    public CardLauncher Launcher;

    public void LaunchCard()
    {
        Launcher.ThrowCard();
    }
}
