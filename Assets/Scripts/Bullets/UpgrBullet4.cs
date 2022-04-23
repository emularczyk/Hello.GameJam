using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrBullet4 : Bullet
{
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }
        if(rb.position.x > -9 || rb.position.x < 9 || rb.position.y > -5 || rb.position.y < 5)
        {
            Destroy(this.gameObject);
        }
    }
}
