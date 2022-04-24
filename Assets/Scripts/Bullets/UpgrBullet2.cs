using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrBullet2 : Bullet
{
    [SerializeField] private GameObject bullet;
    protected override void Start()
    {
        for(int i=-60;i<=60;i+=5)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + i));
        }
        base.Start();
    }
}
