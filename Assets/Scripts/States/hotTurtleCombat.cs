using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotTurtleCombat : MonoBehaviour
{
    public GameObject turtleBulletPrefab;
    public Transform shootPoint;
    public Transform target;
    public void Shoot()
    {
        GameObject turtleBullet = Instantiate(turtleBulletPrefab, shootPoint.position, Quaternion.identity) as GameObject;
        Rigidbody2D body = turtleBullet.GetComponent<Rigidbody2D>();
        Vector2 shootingDir = new Vector2(target.position.x - shootPoint.position.x, target.position.y - shootPoint.position.y);
        body.velocity = shootingDir.normalized * 20;
    }
}
