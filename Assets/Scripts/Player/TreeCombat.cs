using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public GameObject treeBullet;
    public Transform staffPosition;
    public float bulletSpeed;
    public float bulletDuration;

    [SerializeField] protected float attackCD = 0.2f;
    private float lastTimeAttacked;

    public AbstractAction teleport;
    public AbstractAction beam;

    public ModeManager modeManager;

    public Cling[] clingList;

    private Vector3 mousePos;
    private Vector2 shootDir;
    private float lookAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && lastTimeAttacked + attackCD < Time.time)
        {
            animator.SetTrigger("attack");
            //Shoot();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (clingList[0].TryCastAbility())
            {
                modeManager.NewAction(teleport);
                SoundManager.PlaySound(SoundManager.Sound.PlayerTeleport, transform.position);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (clingList[1].TryCastAbility())
            {
                modeManager.NewAction(beam);
                SoundManager.PlaySound(SoundManager.Sound.PlayerChargeUp, transform.position);
            }
        }
    }
    public void Shoot()
    {
        GameObject instBullet = Instantiate(treeBullet, staffPosition.position, Quaternion.identity) as GameObject;
        Rigidbody2D instBody = instBullet.GetComponent<Rigidbody2D>();
        mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z * -1);
        shootDir = Camera.main.ScreenToWorldPoint(mousePos) - staffPosition.position;
        lookAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        instBody.rotation = lookAngle;
        instBody.velocity = shootDir.normalized * bulletSpeed;
        Destroy(instBullet, bulletDuration);

        SoundManager.PlaySound(SoundManager.Sound.PlayerAttack, transform.position);
    }
}
