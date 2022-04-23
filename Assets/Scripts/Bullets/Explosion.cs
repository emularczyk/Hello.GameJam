using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBoolet : Bullet
{
    private GameObject exposion;

    private void OnDestroy()
    {
        Instantiate(exposion,this.transform.position, Quaternion.identity);
    }
}
