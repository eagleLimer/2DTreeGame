using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public string targetTag;
    public float damage;
    public float damageCd = 0f;
    private float dealtDamageTime = 0;
    public float deathTime = 0.1f;
    [SerializeField] protected SoundManager.Sound deathSound;

    public GameObject bulletDeathPrefab;

    private void Start()
    {
        Invoke("Die", deathTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag && Time.time - dealtDamageTime > damageCd)
        {
            dealtDamageTime = Time.time;
            collision.GetComponent<IHealthSystem>().TakeDamage(damage);
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }
    public void Die()
    {
        GameObject bulletDeath = Instantiate(bulletDeathPrefab, transform.position, Quaternion.identity) as GameObject;
        SoundManager.PlaySound(deathSound, transform.position);
        Destroy(bulletDeath, 0.5f);
        Destroy(gameObject);
    }
}
