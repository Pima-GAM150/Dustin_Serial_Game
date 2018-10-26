using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    public float Speed = 5;
    public float FlightTime = 3;
    Vector3 initialDir;

    private IEnumerator Start()
    {
        initialDir = this.transform.forward;
        while(true)
        {
            yield return new WaitForSeconds(FlightTime);

            Destroy(this.gameObject);
        }
        
    }
    private void Update()
    {
        transform.Translate(initialDir*Speed*Time.deltaTime,Space.World);
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
