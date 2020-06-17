using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : AbstractMode
{
    public Transform eyePoint;
    public float viewRange;
    public LayerMask targetLayer;
    public Movement movement;
    public bool movingRight = false;
    private float changeDirTimer = 0;
    public float changeDirTime;

    public EnemyAngry enemyAngry;

    //private float facingRight = -1;
    void Start()
    {
        
    }
    private void OnEnable()
    {
        modeManager.animator.SetBool("walking", true);
    }
    // Update is called once per frame
    void Update()
    {
        SpotTarget();

        if (movingRight)
        {
            movement.MoveRight();
        }
        else
        {
            movement.MoveLeft();
        }
        
        if (Time.time >= changeDirTimer)
        {
            movingRight = !movingRight;
            changeDirTimer = Time.time + Random.Range(changeDirTime * 0.3f, changeDirTime * 2);
            Flip();
        }
    }

    private void SpotTarget()
    {
        Vector2 endPoint = eyePoint.position + Vector3.left * viewRange;
        RaycastHit2D hit = Physics2D.Linecast(eyePoint.position, endPoint, targetLayer);
        if (hit.collider != null)
        {
            modeManager.animator.SetBool("walking", false);
            enemyAngry.SetTarget(hit.collider.transform);
            modeManager.PushMode(enemyAngry);
        }
    }
    void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
