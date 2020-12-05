﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] float damage = 15;
    Attacker attacker;
    //Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        attacker = GetComponent<Attacker>();
        //animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
            attacker.StrikeCurrentTarget(damage);
        }
    }
}