using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : Bullet
{
    void Disapear()
    {
        Destroy(this.gameObject);
    }
}
