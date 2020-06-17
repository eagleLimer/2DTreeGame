using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthSystem
{
    void TakeDamage(float damage);
    void Heal(float heal);

    void Die();
}
