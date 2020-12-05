using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cowboy : MonoBehaviour
{
    Animator animator;
    Attacker attacker;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        attacker = GetComponent<Attacker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        if (otherObject.GetComponent<Defender>())
        {
            Debug.Log("En azından Farketti");
            animator.SetBool("isJumping",true);
            attacker.SetHighForJumping(0.3f);
        }
    }
}
