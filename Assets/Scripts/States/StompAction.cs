using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompAction : AbstractAction
{
    public float duration;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("Finished", duration);
        modeManager.animator.SetTrigger("stomp");
    }

    private void Finished()
    {
        if (enabled)
        {
            modeManager.StopAction();
        }
    }
}
