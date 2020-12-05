using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackToDefenders : MonoBehaviour
{
    Animator animator;
    Attacker attacker;
    Defender defender;
    bool onlineDefender;
    AttackerShooter attackerShooter;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //defender = GetComponent<Defender>();
        attackerShooter = GetComponent<AttackerShooter>();
    }

    // Update is called once per frame
    void Update()
    {
        onlineDefender = attackerShooter.IsDefenderOnLine();
        if (onlineDefender)
        {
            animator.SetBool("isShooting", true);
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }

}
