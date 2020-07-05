using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoSwingAxeScript : AbstractAction
{
    public float duration;
    private void OnEnable()
    {
        Invoke("Finished", duration);
        modeManager.animator.SetTrigger("swingAxe");
    }
    private void Finished()
    {
        if (enabled)
        {
            modeManager.StopAction();
        }
    }
}
