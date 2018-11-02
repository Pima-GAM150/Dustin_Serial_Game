using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTextTimer : MonoBehaviour
{
    public Text text;
    int counter;

    private void Start()
    {
        Cursor.visible = true;
        counter = 0;
    }

    private void OnEnable()
    {
        StartCoroutine(DotDotDot());
    }

    IEnumerator DotDotDot()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);

            text.text = text.text + ".";

            counter++;

            if(counter == 4)
            {
                text.text = text.text + " ";
            }
            else if(counter >= 7 )
            {
                break;
            }
        }

        StopCoroutine(DotDotDot());
    }


}
