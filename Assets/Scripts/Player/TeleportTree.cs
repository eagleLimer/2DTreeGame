using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTree : AbstractAction
{
    [SerializeField] private Rigidbody2D rb;
    public ParticleSystem teleportParticles;
    public float teleportDistance;
    public LayerMask groundLayer;
    private void OnEnable()
    {
        rb.gravityScale = 0;
        rb.velocity *= 0;
        teleportParticles.Play();
        modeManager.animator.SetTrigger("teleport");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Teleport()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1);
        Vector2 endPoint = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 direction = endPoint - new Vector2(transform.position.x, transform.position.y);
        Vector2 directionFull = direction.normalized * teleportDistance;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, teleportDistance, groundLayer);
        Vector2 avoidWall = direction.normalized * 0.5f;
        if (hit.collider == null)
        {
            transform.position = new Vector3(transform.position.x + directionFull.x, transform.position.y + directionFull.y, transform.position.z);
        }
        else
        {
            transform.position = hit.point;
        }
        transform.position = new Vector3(transform.position.x - avoidWall.x, transform.position.y - avoidWall.y, transform.position.z);
        Invoke("TeleportFinish", 0.2f);
        //Camera.main.transform.position = transform.position;
    }
    private void TeleportFinish()
    {
        if (modeManager.currentAction.gameObject == gameObject)
        {
            modeManager.StopAction();
        }
    }
}
