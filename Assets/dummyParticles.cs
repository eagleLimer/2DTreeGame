using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyParticles : MonoBehaviour
{
    public ParticleSystem hitParticles;
    public ParticleSystem deadParticles;
    
    public void HitParticles()
    {
        hitParticles.Play();
    }
    public void DeadParticles()
    {
        deadParticles.Play();
    }
}
