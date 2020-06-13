using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    public Animator animator;
    public Rigidbody2D rb;
    public float damageKnockup = 10;
    public float hitAnimationMin;
    void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(float damage, Vector2 dir)
    {
        if (damage > hitAnimationMin)
        {
            rb.velocity = dir.normalized * 20 + new Vector2(0, damageKnockup);
            animator.SetTrigger("hitTrigger");
        }
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
          
    }
}
