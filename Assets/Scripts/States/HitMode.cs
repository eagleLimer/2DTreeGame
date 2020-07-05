using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode : AbstractAction
{
    [SerializeField] private float hitDuration;
    private float hitFinishedTime;
    private bool postpone = false;
    private void OnEnable()
    {
        Invoke("Finished", hitDuration);
        modeManager.animator.SetTrigger("hit");
    }

    internal void Refresh(float damage)
    {
        hitFinishedTime = hitDuration + Time.time;
        postpone = true;
        modeManager.animator.SetTrigger("hit");
    }
    private void Finished()
    {
        if (postpone)
        {
            Invoke("Finished", Time.time - hitFinishedTime);
            postpone = false;
        }
        else
        {
            //maybe change this to check if modemanager.currentAction = this
            if (enabled)
            {
                modeManager.StopAction();
            }
        }
    }
}
