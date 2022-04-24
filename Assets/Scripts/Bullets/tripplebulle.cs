using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tripplebulle : Bullet
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bullet;
    protected override void Start()
    {
        base.Start();
        Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 30));
        Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - 30));

    }

}
