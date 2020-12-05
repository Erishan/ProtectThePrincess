using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infighting : MonoBehaviour
{
    [SerializeField] float damage = 15;
    //Projectile projectile;
    //DamageDealer damageDealer;
    //Animator animator;
    //GameObject currentTarget;
    //float getHealth;
    //LevelController levelControl;
    //Health health;

    Attacker attacker;

    Defender defender;

    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        defender = GetComponent<Defender>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //var health = otherCollider.GetComponent<Health>();
        //var attacker = otherCollider.GetComponent<Attacker>();
        //if (attacker)
        //{
        //    health.DealDamage(damage);
        //    //Destroy(gameObject);
        //}

        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Attacker>())
        {
            defender.Defend(otherObject);
            defender.StrikeCurrentTarget(damage);
        }
    }

}
