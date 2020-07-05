using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamCling : Cling
{
    [SerializeField] private float energyReg;

    // Update is called once per frame
    void Update()
    {
        if (energy + energyReg * Time.deltaTime < maxEnergy)
        {
            energy += energyReg * Time.deltaTime;
        }
    }
}
