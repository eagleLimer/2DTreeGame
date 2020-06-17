using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngry : AbstractMode
{
    private Transform target;
    public Movement movement;
    public float stopChaseDistance;
    private float facingRight = -1;
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!((transform.position - target.position).magnitude < stopChaseDistance))
        {
            if (target.position.x < transform.position.x)
            {
                movement.MoveLeft();
            }
            else
            {
                movement.MoveRight();
            }
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
