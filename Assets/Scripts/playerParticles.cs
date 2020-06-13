using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerParticles : MonoBehaviour
{

    public ParticleSystem dashParticles;
    public ParticleSystem jumpParticles;
    public ParticleSystem punchParticles;
    public void playDashParticles()
    { 
        dashParticles.Play();
    }
    public void PlayJumpParticles()
    {
        jumpParticles.Play();
    }
    public void PlayPunchParticles()
    {
        punchParticles.Play();
    }

}
