
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractMode : MonoBehaviour
{
    public int interruptPriority;
    public ModeManager modeManager;
    /*public SerializableDictionary<AbstractAction, int> actionDict;
    //change this to an int list in case there is any issue with memory or anything, but I think it should be fine since it should be accessed as a reference.
    private AbstractAction[] actionProbabilityList;
    private void Start()
    {
        actionProbabilityList = new AbstractAction[100];
        if (actionDict.Count > 0)
        {
            int total = 0;
            foreach (AbstractAction action in actionDict.Keys)
            {
                total += actionDict[action];
            }
            float percentageLoc = 0;
            foreach (AbstractAction action in actionDict.Keys)
            {
                float percentage = 100 * actionDict[action] / total;
                for (int i = (int)percentageLoc; i < percentage + percentageLoc; i++)
                {
                    actionProbabilityList[i] = action;
                }
                percentageLoc += percentage;
            }
        }
    }
    public AbstractAction GetRandomAction()
    {
        return actionProbabilityList[UnityEngine.Random.Range(0, 100)];
    }*/
    public AbstractAction GetRandomAction(AbstractAction[] actions)
    {
        return actions[UnityEngine.Random.Range(0, actions.Length)];
    }
}
