using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleMovement : MonoBehaviour
{
    public Transform eyePoint;
    public float viewRange;
    public LayerMask targetLayer;
    public Transform target;

    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D body;
    private float facingRight = -1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Vector2 endPoint = eyePoint.position + Vector3.left * viewRange;
            RaycastHit2D hit = Physics2D.Linecast(eyePoint.position, endPoint, targetLayer);
            if (hit.collider != null)
            {
                target = hit.collider.transform;
            }
        }
        else
        {
            if(target.position.x < transform.position.x)
            {
                body.velocity = new Vector2(-moveSpeed, body.velocity.y);
                
            }
            else
            {
                body.velocity = new Vector2(moveSpeed, body.velocity.y);
            }

        }
        if (facingRight == 1 && body.velocity.x < 0)
        {
            Flip();
        }
        else if (facingRight == -1 && body.velocity.x > 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        facingRight = facingRight * -1;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
