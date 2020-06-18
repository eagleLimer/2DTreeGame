using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealthSystem
{
    public float maxHealth;
    public float hitAnimationMin;
    public HitMode hitMode;
    public ModeManager modeManager;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        if (modeManager.currentMode == hitMode)
        {
            hitMode.Refresh(damage);
        }
        else
        {
            modeManager.NewAction(hitMode);
        }
        if (health <= 0)
        {
            Destroy(gameObject, 1);
            Die();
        }
    }

    public void Die()
    {
        //animator.SetBool("dead", true);
    }
    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
