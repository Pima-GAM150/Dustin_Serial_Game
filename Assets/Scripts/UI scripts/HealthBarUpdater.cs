using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUpdater : MonoBehaviour
{
    public Character character;

    public Slider HealthBar;

    private void Update()
    {
        HealthBar.value = character.Health / character.MaxHealth;
    }

}
