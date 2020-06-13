using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinoNeonScript : MonoBehaviour
{
    public ParticleSystem stompParticles;
    public ParticleSystem axeParticles;

    public void playStompParticles()
    {
        stompParticles.Play();
        //particles.
    }
    public void playAxeParticles()
    {
        axeParticles.Play();
    }
}
