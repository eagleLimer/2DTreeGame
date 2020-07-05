using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthSystem
{
    void TakeDamage(float damage);
    void KnockBack(Vector3 dir, float force);
    void Heal(float heal);

    void Die();
    float getHealthPercentage();
}
