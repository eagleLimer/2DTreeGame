using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportCling : Cling
{
    public float energyReg;
    private void OnEnable()
    {
        //animate cling teleportAni;
    }
    // Update is called once per frame
    void Update()
    {
        float energyRegenerated = energyReg * Time.deltaTime;
        if (energy + energyRegenerated < maxEnergy)
        {
            energy += energyRegenerated;
        }
    }
}
