using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToInvaders : MonoBehaviour
{
    Animator animator;
    Attacker attacker;
    bool onlineAttacker;
    Shooter shooter;
    float damage = 10f;
    private void Start()
    {
        shooter = GetComponent<Shooter>();
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
        //shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if(shooter != null)
        {
            onlineAttacker = shooter.IsAttackerOnLine();
            Debug.Log("Online Attacker is " + onlineAttacker);
            if (onlineAttacker)
            {
                //Debug.Log("Defender Should Pew PEW");
                animator.SetBool("isAttacking", true);
                //shooter.Fire();
            }
            else
            {
                //Debug.Log("Defender should wait");
                animator.SetBool("isAttacking", false);
            }
        }
    }

    private void Fire()
    {
        shooter.Fire();
    }

    //private void AttackWithYourKnife(Collider2D otherCollider)
    //{
    //    var health = otherCollider.GetComponent<Health>();
    //    var attacker = otherCollider.GetComponent<Attacker>();
    //    animator.SetBool("isAttacking", true);
    //    if (attacker)
    //    {
    //        health.DealDamage(damage);
    //    }
    //}

 
}
