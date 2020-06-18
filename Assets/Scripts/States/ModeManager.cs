using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public AbstractMode startMode;
    public Animator animator;
    public AbstractMode currentMode;
    public AbstractAction currentAction;
    private Stack<AbstractMode> modeStack;
    //public List<AbstractMode> modes;
    // Start is called before the first frame update
    void Start()
    {
        modeStack = new Stack<AbstractMode>();
        modeStack.Push(startMode);
        currentMode = startMode;
    }

    public void PushMode(AbstractMode mode)
    {
        mode.enabled = true;
        modeStack.Peek().enabled = false;
        modeStack.Push(mode);
        currentMode = mode;
    }
    public void PopMode()
    {
        modeStack.Pop();
        if (modeStack.Count > 0)
        {
            modeStack.Peek().enabled = true;
            currentMode = modeStack.Peek();
        }
    }
    public void NewAction(AbstractAction action)
    {
        if (currentAction == null)
        {
            if (action.priority > currentMode.interruptPriority)
            {
                currentAction = action;
                action.enabled = true;
            }
        }
        else
        {
            if (action.priority > currentAction.interruptPriority)
            {
                currentAction.enabled = false;
                currentAction = action;
                action.enabled = true;
            }
        }
    }
    public void StopAction()
    {
        currentAction.enabled = false;
        currentAction = null;
    }
}
