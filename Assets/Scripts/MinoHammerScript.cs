using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoHammerScript : MonoBehaviour
{
    public float minoDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<IHealthSystem>().TakeDamage(minoDamage);
        }
    }
}
