using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[Serializable]
public abstract class AbstractMode : MonoBehaviour
{
    public int priority;
    public int interruptPriority;
    public ModeManager modeManager;
}
