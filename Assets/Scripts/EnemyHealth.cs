using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHealthSystem
{
    public float maxHealth;
    public float hitAnimationMin;
    private HitMode hitMode;
    private AbstractAction deathAction;
    private ModeManager modeManager;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        hitMode = GetComponent<HitMode>();
        deathAction = GetComponent<DeathAction>();
        modeManager = GetComponent<ModeManager>();
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
            Die();
        }
    }
    public void KnockBack(Vector3 dir, float force)
    {
        
    }

    public void Die()
    {
        modeManager.NewAction(deathAction);
        //animator.SetTrigger("dead");
    }
    public void Heal(float heal)
    {
        health += heal;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    public float getHealthPercentage()
    {
        return health / maxHealth;
    }
}
