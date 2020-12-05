using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectilePrefab;
    [SerializeField] AttackerSpawn SpawnerInMyLane;
    AttackerSpawn attackerSpawner;
    Animator animator;
    //bool onlineAttacker = false;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }


    private void SetLaneSpawner(){
        AttackerSpawn[] attackerSpawners = FindObjectsOfType<AttackerSpawn>();
        foreach (AttackerSpawn attackerSpawner in attackerSpawners)
        {
            bool IsCloseEnough = (Mathf.Abs(attackerSpawner.transform.position.x - transform.position.x) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                SpawnerInMyLane = attackerSpawner;
            }
        }
    }

    public bool IsAttackerOnLine()
    {
        if (SpawnerInMyLane != null)
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
        Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(new Vector3(1,0,0))) as Projectile;
    }
}
