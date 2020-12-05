﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1f;
    int damage;
    Projectile projectile;
    DamageDealer damageDealer;
    Animator animator;
    GameObject currentTarget;
    float getHealth;
    LevelController levelControl;
    Health health;
    //[SerializeField] Attacker[] attackers;

    private void Awake()
    {
        FindObjectOfType<LevelController>().AddAttacker();
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelController>().AttackerKilled();
    }

    private void Start()
    {
       projectile = gameObject.GetComponent<Projectile>();
       animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (animator.GetBool("isAttacking"))
        {
            return;
        }
        else
        {
            transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime);
    }

    public void Attack(GameObject target)
    {
        animator.SetBool("isAttacking", true);
        currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!currentTarget) { animator.SetBool("isAttacking", false); }
        health = currentTarget.GetComponent<Health>();
        if (health)
        {
            health.DealDamage(damage);
            //currentSpeed = 0;
        }
        if (!health)
        {
            //currentSpeed = currentSpeed;
            animator.SetBool("isAttacking", false);
        }
    }

}