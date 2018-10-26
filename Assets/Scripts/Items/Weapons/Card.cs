using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float RotationSpeed = 5;
    public float Speed = 5;
    public float FlightTime = 2;

    private IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(FlightTime);

            Destroy(this.gameObject);
        }
        
    }
    private void Update()
    {
        transform.Rotate(Vector3.up, RotationSpeed);
        transform.Translate();
    }
    private void OnCollisionEnter(Collision collision)
    {
        Player player = FindObjectOfType<Player>();
        if(collision.gameObject.tag == "Boss")
        {
            IDamageable boss = FindObjectOfType<Boss>();
            Weapon w = player.EquipedWeapon.GetComponent<Weapon>();
            boss.TakeDamage(player.Damage + w.Damage);
        }
        Destroy(this.gameObject);
    }

}
