using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave6 : MonoBehaviour
{
    private DogHutEnemy dogHutEnemy;
    private Monitor monitor;

    private static bool waitAllLeft = false;

    void Start()
    {
        monitor = GameObject.Find("GameManager").GetComponent<Monitor>();
        dogHutEnemy = this.GetComponent<DogHutEnemy>();
    }

    void Update()
    {
        stop();
        if (waitAllLeft)
            dogHutEnemy.freezeMovement();
    }

    void stop()
    {
        if (transform.position.x < (monitor.leftWall + 5f))
        {
            StartCoroutine(WaitAllLeft());
        }
    }

    IEnumerator WaitAllLeft()
    {
        yield return new WaitForSeconds(2);
        waitAllLeft = true;
    }
}
