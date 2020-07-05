using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cling : MonoBehaviour
{
    public Ability ability;
    public float maxEnergy;
    public float energy;
    public int abilityKeyCode;
    public float cooldown;
    private float lastCastTime;
    //public float energyReg = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        maxEnergy = 100;
        energy = maxEnergy;
        lastCastTime = -10;
    }

    public bool TryCastAbility()
    {
        if (ability.energyRequired <= energy && Time.time > lastCastTime + cooldown)
        {
            ability.enabled = true;
            energy -= ability.energyRequired;
            lastCastTime = Time.time;
            return true;
        }
        return false;
    }
    public float getEnergyPercentage()
    {
        return energy / maxEnergy;
    }
}
