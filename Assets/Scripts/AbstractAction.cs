using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class AbstractAction : MonoBehaviour
{
    public float priority;
    public float interruptPriority;
    public bool canMove;
    //public float duration;
    [NonSerialized] public ModeManager modeManager;

    private void Awake()
    {
        modeManager = gameObject.GetComponent<ModeManager>();
    }
}
