using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    public Text time;

    int TimePlayed;

    private void Start()
    {
        TimePlayed = 0;
        time.text = time.text + TimePlayed.ToString();
        StartCoroutine(GameTimer());
    }
    

    IEnumerator GameTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            TimePlayed++;

            time.text = "Time:" + TimePlayed;
        }
    }

}
