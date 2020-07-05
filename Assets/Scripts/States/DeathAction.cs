using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAction : AbstractAction
{
    public ParticleSystem deathParticles;
    private void Start()
    {
        modeManager.animator.SetTrigger("dead");
    }
    public void DestroyEntity()
    {
        deathParticles.Play();
        Destroy(gameObject);
    }
    public void PlayDeathParticles()
    {
        deathParticles.Play();
    }
}
