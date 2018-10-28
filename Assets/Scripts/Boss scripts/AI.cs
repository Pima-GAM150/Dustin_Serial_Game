using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public Naviation NavScrpit;
    Boss boss;
    Health[] restore;
    DamageBoost[] boost;

    Vector3 MyPos, Hpos, ClosestH;
    float Dist, prevDist;
    float DamageDesire;

    private void Start()
    {
        boss = this.gameObject.GetComponent<Boss>();
        StartCoroutine(DoIWantMoreDamage());
    }

    private void FixedUpdate()
    {
        DoINeedHealth();
    }

    private IEnumerator DoIWantMoreDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            DamageDesire = UnityEngine.Random.Range(0, 100);

            if (DamageDesire <= 50)
            {

            }
            else
            {
                StopCoroutine("ChasePlayer");

                NavScrpit.Agent.speed = 10;

                boost = FindObjectsOfType<DamageBoost>();

                prevDist = 7000;

                foreach (DamageBoost db in boost)
                {
                    MyPos = this.gameObject.transform.position;
                    Hpos = db.transform.position;
                    Dist = Vector3.Distance(MyPos, Hpos);

                    if (Dist < prevDist)
                    {
                        ClosestH = Hpos;
                        prevDist = Dist;
                    }

                }

                NavScrpit.Agent.SetDestination(ClosestH);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            if (boss.Health > boss.MaxHealth * .4f)
            {
                NavScrpit.StartCoroutine(NavScrpit.ChasePlayer(3));
                NavScrpit.Agent.speed = 4;
            }
        }
    }

    void DoINeedHealth()
    {
        if (boss.Health <= boss.MaxHealth * .4f)
        {
            NavScrpit.Agent.speed = 10;
            StopCoroutine("ChasePlayer");
            restore = FindObjectsOfType<Health>();
            prevDist = 7000;

            foreach (Health h in restore)
            {
                MyPos = this.gameObject.transform.position;
                Hpos = h.transform.position;
                Dist = Vector3.Distance(MyPos, Hpos);

                if (Dist < prevDist)
                {
                    ClosestH = Hpos;
                    prevDist = Dist;
                }

            }

            NavScrpit.Agent.SetDestination(ClosestH);
        }
    }


}
