using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLauncher : MonoBehaviour
{
    public GameObject CardPrefab;

    public void ThrowCard()
    {
        Instantiate(CardPrefab);
    }
	
}
