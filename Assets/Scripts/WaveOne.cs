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
        StartCoroutine(WaitTo(3));
    }
    IEnumerator WaitTo(int number)
    {

        yield return new WaitForSeconds(number);
        enemy.freezeMovement();
    }
}
