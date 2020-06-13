using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public Animator animator;
    public float hitAnimationMin;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject, 1);
            Die();
        }
        else if (damage > hitAnimationMin)
        {
            animator.SetTrigger("hit");
        }
    }

    public void Die()
    {
        animator.SetBool("dead", true);
    }
    public void Heal(float heal)
    {
        health += heal;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
