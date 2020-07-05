using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour, IHealthSystem
{
    public float maxHealth;
    public Animator animator;
    public float hitAnimationMin;
    private float health;
    public string menuSceneName;
    private HitMode hitAction;
    private ModeManager modeManager;
    private Rigidbody2D rb;

    private void Awake()
    {
        modeManager = GetComponent<ModeManager>();
        hitAction = GetComponent<HitMode>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject, 1);
            Die();
        }
        if (modeManager.currentAction == hitAction)
        {
            hitAction.Refresh(damage);
        }
        else
        {
            modeManager.NewAction(hitAction);
        }
    }
    public void KnockBack(Vector3 dir, float force)
    {
        rb.velocity = dir * force;
    }


    public void Die()
    {
        animator.SetBool("dead", true);
        Invoke("PlayerDead", 1);
    }
    private void PlayerDead()
    {
        SceneManager.LoadScene(menuSceneName);
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
