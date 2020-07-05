using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minoParticleScript : MonoBehaviour
{

    public ParticleSystem hammerParticles;
    public ParticleSystem stompParticles;

    public void PlayHammerParticles()
    {
        hammerParticles.Play();
    }
    public void PlayStompParticles()
    {
        stompParticles.Play();
    }

    public void PlayStompSound()
    {
        SoundManager.PlaySound(SoundManager.Sound.MinotaurStomp, transform.position);
    }
    public void PlayHammerSound()
    {
        SoundManager.PlaySound(SoundManager.Sound.MinotaurHammer, transform.position);
    }
}
