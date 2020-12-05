using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToInvaders : MonoBehaviour
{
    Animator animator;
    Attacker attacker;
    bool onlineAttacker;
    Shooter shooter;
    private void Start()
    {
        shooter = GetComponent<Shooter>();
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    private void Update()
    {
        if(shooter != null)
        {
            onlineAttacker = shooter.IsAttackerOnLine();
            Debug.Log("Online Attacker is " + onlineAttacker);
            if (onlineAttacker)
            {
                animator.SetBool("isShooting", true);
            }
            else
            {
                animator.SetBool("isShooting", false);
            }
        }
    }

    //private void Fire()
    //{
    //    shooter.Fire();
    //}

}
