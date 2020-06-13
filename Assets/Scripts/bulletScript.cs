using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public LayerMask layerMask;
    public string targetTag;
    public float damage;
    public float damageCd = 0f;
    private float dealtDamageTime = 0;
    public float deathTime = 0.1f;

    public GameObject bulletDeathPrefab;

    private void Start()
    {
        Invoke("Die", deathTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == targetTag && Time.time - dealtDamageTime > damageCd)
        {
            dealtDamageTime = Time.time;
            collision.GetComponent<HealthSystem>().TakeDamage(damage);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject bulletDeath = Instantiate(bulletDeathPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(bulletDeath, 0.5f);
        Destroy(gameObject);
    }
    public void Die()
    {
        GameObject bulletDeath = Instantiate(bulletDeathPrefab, transform.position, Quaternion.identity) as GameObject;
        Destroy(bulletDeath, 0.5f);
        Destroy(gameObject);
    }
}
