using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    //public Player player;
    public float coolDown;
    private float coolDownTimer = 0;
    public Rigidbody2D rb;
    public PlayerMovement playerMovement;
    public float attackDuration;
    private bool attacking = false;
    public float dashMultiplier;
    private float dashSpeed;

    public LayerMask enemyLayers;
    public float explosionRadius;
    public Transform explosionPoint;
    public float attackDamage;
    public GameObject damageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("punching", true);
        }
        else
        {
            animator.SetBool("punching", false);
        }
        coolDownTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.F) && coolDownTimer <= 0)
        {
            dashSpeed = transform.localScale.x * dashMultiplier + rb.velocity.x;
            rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
            animator.SetBool("dash", true);
            coolDownTimer = coolDown;
            playerMovement.enabled = false;
            attacking = true;
            //rb.gravityScale = 0;
        }
        if (attacking)
        {
            if (-(coolDownTimer - coolDown) < attackDuration)
            {
                rb.velocity = new Vector2(dashSpeed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(dashSpeed/2, rb.velocity.y);
                attacking = false;
                playerMovement.enabled = true;
                animator.SetBool("dash", false);
            }
        }
    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(explosionPoint.position, explosionRadius, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<HealthSystem>().TakeDamage(attackDamage/*, enemy.transform.position - transform.position*/);
            Vector2 damagePoint = enemy.ClosestPoint(transform.position);
            GameObject text = (GameObject)Instantiate(damageText, new Vector3(damagePoint.x, damagePoint.y, 0), Quaternion.identity);
            text.GetComponent<TextMesh>().text = attackDamage.ToString();
            Destroy(text, 0.7f);
            //damageText.GetComponent<TextMesh>().text = attackDamage.ToString();
            //damageText.transform.position = new Vector3(damagePoint.x, damagePoint.y, 0);
        }
    }
}
