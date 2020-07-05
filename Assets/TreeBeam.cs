using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBeam : AbstractAction
{
    //change to movement.Freeze();
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private ParticleSystem chargeParticles;
    [SerializeField] private GameObject particleAttractor;
    [SerializeField] private LineRenderer line;
    [SerializeField] private float beamRange;
    [SerializeField] private Transform staffPos;
    [SerializeField] private GameObject beam;
    [SerializeField] private ParticleSystem beamParticles;
    [SerializeField] private ParticleSystem beamShockwaves;
    private void OnEnable()
    {
        rb.gravityScale = 0;
        rb.velocity *= 0;
        //teleportParticles.Play();
        modeManager.animator.SetTrigger("beam");
    }
    private void calculateDir()
    {
        //Input.mousePosition;
    }
    public void Beam()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1);
        Vector2 endPoint = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = endPoint - new Vector2(staffPos.position.x, staffPos.position.y);
        beam.transform.position = staffPos.position;
        if (direction.y < 0)
        {
            beam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Vector2.Angle(new Vector2(1, 0), direction)));
        }
        else
        {
            beam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.Angle(new Vector2(1, 0), direction)));
        }
        beamParticles.Play();
        beamShockwaves.Play();
        rb.gravityScale = 0;
        rb.velocity *= 0;
        line.enabled = true;
        /*Vector2 direction = endPoint - new Vector2(staffPoint.position.x, staffPoint.position.y);
        Vector2 directionFull = direction.normalized * beamRange;*/
        line.GetComponent<LineRenderer>().SetPosition(1, new Vector3(beamRange, 0, 0));
    }
    public void BeamFinished()
    {
        particleAttractor.SetActive(false);
        line.enabled = false;
        if (modeManager.currentAction != null && modeManager.currentAction.gameObject == gameObject)
        {
            modeManager.StopAction();
        }
    }
    public void ChargeBeamParticles()
    {
        chargeParticles.Play();
        particleAttractor.SetActive(true);
    }
    public void ChargeBeamParticlesFinished()
    {
        chargeParticles.Clear();
        chargeParticles.Stop();
        particleAttractor.SetActive(false);
    }
}
