using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private float damage = 20;
    [SerializeField] private float knockBackForce = 20;
    [SerializeField] private float damageCD = 1;
    [SerializeField] private string targetTag;
    private float lastTimeDealtDamage = -5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == targetTag)
        {
            GameObject collidedObject = collision.gameObject;
            Vector3 dir = collidedObject.transform.position - transform.position;

            if (lastTimeDealtDamage + damageCD < Time.time)
            {
                collidedObject.GetComponent<IHealthSystem>().TakeDamage(damage);
                collidedObject.GetComponent<IHealthSystem>().KnockBack(dir, knockBackForce);
            }
        }
    }
}
