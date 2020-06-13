using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public Mode startMode;
    private Stack<Mode> modes;
    // Start is called before the first frame update
    void Start()
    {
        modes.Push(startMode);
    }

    // Update is called once per frame
    void Update()
    {
        modes.Peek().Update();
    }
    // no need to update the top of the stack as it has a update that updates automatically
    // instead, have all elements in the stack except the top as mode.SetActive(false);
}
