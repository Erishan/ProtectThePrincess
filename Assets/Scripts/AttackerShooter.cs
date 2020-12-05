using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerShooter : MonoBehaviour
{
    [SerializeField] AttackProjectile attackProjectilePrefab;
    [SerializeField] Defender defenderInMyLane;
    //AttackerSpawn attackerSpawner;
    [SerializeField] Defender[] defendersInMyLane;
    Animator animator;
    //bool onlineAttacker = false;

    private void Start()
    {
        SetLaneDefender();
        animator = GetComponent<Animator>();
    }

    private void SetLaneDefender()
    {
        defendersInMyLane = FindObjectsOfType<Defender>();
        foreach(Defender defender in defendersInMyLane)
        {
            bool isDefenderInMyLane = (Mathf.Abs(defender.transform.position.x - transform.position.x) <= Mathf.Epsilon);
            if (isDefenderInMyLane)
            {
                defenderInMyLane = defender;
            }
        }
    }

    public bool IsDefenderOnLine()
    {
        if(defenderInMyLane != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Fire()
    {
        AttackProjectile projectile = Instantiate(attackProjectilePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90))) as AttackProjectile;
    }
}
