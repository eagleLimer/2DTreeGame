using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelClings : MonoBehaviour
{
    public Rigidbody2D body;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 repelDir = (gameObject.transform.position - collision.gameObject.transform.position).normalized;
        body.velocity += new Vector2(repelDir.x, repelDir.y);
    }
}
