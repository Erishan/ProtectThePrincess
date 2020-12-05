using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject gotShotVFX;
    [SerializeField] GameObject deadAttackerParticlesVFX;
    //Attacker attacker;

    private void Start()
    {
        //attacker = FindObjectOfType<Attacker>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        var gotShot = Instantiate(gotShotVFX, transform.position, Quaternion.identity) as GameObject;
        Destroy(gotShot, 0.5f);
        if (health <= 0)
        {
            Destroy(gameObject);
            var deadAttackerParticles = Instantiate(deadAttackerParticlesVFX, transform.position, Quaternion.identity) as GameObject;
            Destroy(deadAttackerParticles, 0.5f);
        }
    }

    public float GetHealth()
    {
        return health;
    }
}
