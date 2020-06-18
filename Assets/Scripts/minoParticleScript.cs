using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minoParticleScript : MonoBehaviour
{

    public ParticleSystem hammerParticles;
    public void PlayHammerParticles()
    {
        hammerParticles.Play();
    }
}
