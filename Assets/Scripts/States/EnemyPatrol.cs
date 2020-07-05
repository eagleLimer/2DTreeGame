using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : AbstractMode
{
    public Transform eyePoint;
    public float viewRange;
    public LayerMask targetLayer;
    public LayerMask groundLayer;
    public Movement movement;
    public bool movingRight = false;
    private float changeDirTimer = 0;
    public float changeDirTime;
    public bool chilling = false;

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
        AvoidWall();
        SpotTarget();
        if (!chilling)
        {
            if (movingRight)
            {
                movement.MoveRight();
            }
            else
            {
                movement.MoveLeft();
            }
        }
        if (Time.time >= changeDirTimer)
        {
            if (!chilling)
            {
                chilling = true;
                modeManager.animator.SetBool("walking", false);
                changeDirTimer = Time.time + Random.Range(changeDirTime * 0.3f, changeDirTime * 1);
            }
            else
            {
                if (Random.Range(0, 2) == 1)
                {
                    movingRight = !movingRight;
                    movement.Flip();

                }
                modeManager.animator.SetBool("walking", true);
                changeDirTimer = Time.time + Random.Range(changeDirTime * 0.3f, changeDirTime * 2);
                chilling = false;
            }
        }
    }

    private void AvoidWall()
    {
        Vector2 endPoint = eyePoint.position + Vector3.right * 1 * movement.currentXDir;
        RaycastHit2D hit = Physics2D.Linecast(eyePoint.position, endPoint, groundLayer);
        if (hit.collider != null)
        {
            movingRight = !movingRight;
            movement.Flip();
        }
    }
    private void SpotTarget()
    {
        Vector2 endPoint = eyePoint.position + Vector3.right * viewRange * movement.currentXDir;
        RaycastHit2D hit = Physics2D.Linecast(eyePoint.position, endPoint, targetLayer);
        if (hit.collider != null)
        {
            modeManager.animator.SetBool("walking", false);
            enemyAngry.SetTarget(hit.collider.transform);
            modeManager.PushMode(enemyAngry);
        }
        else
        {
            hit = Physics2D.Linecast(eyePoint.position, endPoint - new Vector2(0, 2), targetLayer);
            if (hit.collider != null)
            {
                modeManager.animator.SetBool("walking", false);
                enemyAngry.SetTarget(hit.collider.transform);
                modeManager.PushMode(enemyAngry);
            }
        }
    }
}
