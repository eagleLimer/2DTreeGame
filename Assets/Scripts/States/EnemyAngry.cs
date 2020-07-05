using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngry : AbstractMode
{
    private Transform target;
    public Movement movement;
    public float stopChaseDistance;
    public AbstractAction enableAction;
    public AbstractAction[] meleeMoves;
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        modeManager.NewAction(enableAction);
    }

    // Update is called once per frame
    void Update()
    {
        if (modeManager.currentAction == null)
        {
            //print("noAction!");
            modeManager.animator.SetBool("walking", true);
            if ((transform.position - target.position).magnitude < stopChaseDistance && modeManager.currentAction == null)
            {
                modeManager.NewAction(GetRandomAction(meleeMoves));
                //print("started new attack");
            }
            else
            {
                if (target.position.x < transform.position.x && movement.currentXDir == 1)
                {
                    movement.Flip();
                }
                else if (target.position.x > transform.position.x && movement.currentXDir == -1)
                {
                    movement.Flip();
                }
                if (movement.currentXDir == 1)
                {
                    movement.MoveRight();
                }
                else
                {
                    movement.MoveLeft();
                }
            }
        }
        else
        {
            modeManager.animator.SetBool("walking", false);
            
        }

    }
    
}
