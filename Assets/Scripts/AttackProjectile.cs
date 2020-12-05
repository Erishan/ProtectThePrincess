using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackProjectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float damage = 10f;
    [SerializeField] float destroyTheProjectile = 2f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * projectileSpeed * Time.deltaTime);
        Destroy(gameObject, destroyTheProjectile);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {

        var health = otherCollider.GetComponent<Health>();
        var defender = otherCollider.GetComponent<Defender>();
        if (defender)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }

}
