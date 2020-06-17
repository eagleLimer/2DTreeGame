using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMode : AbstractMode
{
    public float hitDuration;
    private float hitFinishedTime;
    private bool postpone = false;
    private void OnEnable()
    {
        //this might screw things up as it might pop the wrong mode if for example another invoke is currently waiting to push another mode. A fix would be to specify what mode is to be popped.
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
            modeManager.PopMode();
        }
    }
}
