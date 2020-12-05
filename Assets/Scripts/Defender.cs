using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] float defenderHealth = 100f;
    int damage;
    Animator animator;
    GameObject currentTarget;
    float getHealth;
    LevelController levelControl;
    Health health;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Defend(GameObject target)
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
        }
        if (!health)
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
