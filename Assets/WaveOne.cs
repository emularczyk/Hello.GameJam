using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveOne : MonoBehaviour
{
    private DogHutEnemy enemy;
    void Start()
    {
        enemy=this.GetComponent<DogHutEnemy>();
    }

    void Update()
    {
        if (transform.position.y < 3.5f)
        {
            enemy.FreezMovemnt();
        } 
    }
}
