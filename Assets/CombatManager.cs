using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CombatManager: MonoBehaviour
{
    public float damage;

    public int knockbackPower;

    public float hitMultiplyer;

    private void Start()
    {
        damage = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            ApplyDamage(other);
        }
    }

    public void ApplyDamage(Collider collider)
    {

        damage += knockbackPower * hitMultiplyer;

        hitMultiplyer += damage % (damage/ 100);

        Rigidbody enemy = GetComponent<Rigidbody>();
        enemy.AddForce(Vector3.back * damage, ForceMode.Impulse);

        

        Debug.Log(damage);

    }



}
