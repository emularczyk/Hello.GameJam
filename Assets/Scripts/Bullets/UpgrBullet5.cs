using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrBullet5 :Bullet
{
    [SerializeField] private float rotateSpeed;

    private Rigidbody2D rb;
    private Vector2 direction;
    private Quaternion rotateToTarget;
    private Enemy closetstEnemy;
    private float distanceToClosestEnemy;

     protected override void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected override void Move()
    {
        findeClosestEnemy();
        if(closetstEnemy != null)
        {
            direction = (closetstEnemy.transform.position - transform.position).normalized;
            float rotate = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotateToTarget = Quaternion.AngleAxis(rotate + transform.rotation.z - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.fixedDeltaTime * rotateSpeed);
            rb.velocity = transform.up * speed;
        }
        else
        {
            base.Move();
        }
    }
    private void findeClosestEnemy()
    {
        distanceToClosestEnemy = Mathf.Infinity;
        closetstEnemy = null;
        Enemy[] allEnemies =GameObject.FindObjectsOfType<Enemy>();
        foreach(Enemy currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if(distanceToEnemy< distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closetstEnemy = currentEnemy;
            }     
        }
    }

}
