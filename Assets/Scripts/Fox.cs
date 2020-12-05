using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    [SerializeField] float damage = 15;
    Attacker attacker;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        attacker = GetComponent<Attacker>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Gravestone>())
        {
            //animator.SetBool("isJumping", true);
            StartCoroutine(Jump());
            //attacker.Jump();
            //animator.SetTrigger("isJumping");
        }
        else if (!otherObject.GetComponent<Gravestone>() && otherObject.GetComponent<Defender>())
        {
            attacker.Attack(otherObject);
            attacker.StrikeCurrentTarget(damage);
        }
    }

    IEnumerator Jump()
    {
        animator.SetBool("isJumping", true);
        yield return new WaitForEndOfFrame();
        animator.SetBool("isJumping", false);
    }
}
