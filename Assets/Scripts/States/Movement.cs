using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    public float jumpSpeed;
    public Rigidbody2D rb;

    public void MoveLeft()
    {
        rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
    }

    public void MoveRight()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }
    public void Jump()
    {

    }
}
