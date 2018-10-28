using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Naviation : MonoBehaviour
{
    public int Seconds;
    public GameObject ThePlayer;
    public NavMeshAgent Agent;
    public Vector3 Offset;
    
	void Start ()
    {
        Agent.speed = 4;
        StartCoroutine(ChasePlayer(Seconds));
	}

    public IEnumerator ChasePlayer(int secs)
    {
        while(true)
        {
            yield return new WaitForSeconds(secs);

            Agent.SetDestination(ThePlayer.transform.position + Offset);
        }
    }
}
