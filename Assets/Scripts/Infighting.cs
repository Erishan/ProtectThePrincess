using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infighting : MonoBehaviour
{
    [SerializeField] float damage = 15;

    Attacker attacker;

    Defender defender;

    // Start is called before the first frame update
    void Start()
    {
        defender = GetComponent<Defender>();
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Attacker>())
        {
            defender.Defend(otherObject);
            defender.StrikeCurrentTarget(damage);
        }
    }

}
