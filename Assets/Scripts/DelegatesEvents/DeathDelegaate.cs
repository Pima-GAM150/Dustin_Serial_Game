using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDelegaate : MonoBehaviour
{
    public delegate void DeathEventHandler(Character death);
    public static DeathEventHandler OnDeathEvent;


    public void DeathEvent(Character death)
    {
        if(OnDeathEvent != null)
        {
            OnDeathEvent(death);
        }        
    }
	
}
