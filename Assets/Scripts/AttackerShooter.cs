using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerShooter : MonoBehaviour
{
    [SerializeField] AttackProjectile attackProjectilePrefab;
    [SerializeField] Defender defenderInMyLane;
    //AttackerSpawn attackerSpawner;
    Defender isDefenderInMyLane;
    Animator animator;
    //bool onlineAttacker = false;

    private void Start()
    {
        //SetLaneSpawner();
        animator = GetComponent<Animator>();
    }


    //private void SetLaneSpawner()
    //{
    //    AttackerSpawn[] attackerSpawners = FindObjectsOfType<AttackerSpawn>();
    //    foreach (AttackerSpawn attackerSpawner in attackerSpawners)
    //    {
    //        bool IsCloseEnough = (Mathf.Abs(isDefenderInMyLane.transform.position.x - transform.position.x) <= Mathf.Epsilon);
    //        if (IsCloseEnough)
    //        {
    //            isDefenderInMyLane = defenderInMyLane;
    //        }
    //    }
    //}

    //public bool IsAttackerOnLine()
    //{
    //    if (defenderInMyLane != null)
    //    {
    //        //if (SpawnerInMyLane.transform.childCount <= 0)
    //        //{
    //        //    return false;
    //        //}
    //        //else
    //        //{
    //        //    return true;
    //        //}
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //    //return onlineAttacker;

    //}

    public void Fire()
    {
        AttackProjectile projectile = Instantiate(attackProjectilePrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 90))) as AttackProjectile;
    }
}
