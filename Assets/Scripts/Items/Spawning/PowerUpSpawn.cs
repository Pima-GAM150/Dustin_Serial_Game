using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawn : MonoBehaviour
{
    public GameObject Health, Damage, MaxHealth, SpeedBoost;
    public int SpawnSpeed;

    private void Start()
    {
        StartCoroutine("SpawnPowerUps");
    }

    IEnumerator SpawnPowerUps()
    {
        while(true)
        {
            yield return new WaitForSeconds(SpawnSpeed);

            Instantiate(Health, new Vector3(Random.Range(50, 450),10, Random.Range(50, 450)), Quaternion.identity);
            Instantiate(Damage, new Vector3(Random.Range(50, 450), 10, Random.Range(50, 450)), Quaternion.identity);
            Instantiate(MaxHealth, new Vector3(Random.Range(50, 450), 10, Random.Range(50, 450)), Quaternion.identity);
            Instantiate(SpeedBoost, new Vector3(Random.Range(50, 450), 10, Random.Range(50, 450)), Quaternion.identity);
        }
    }
}
