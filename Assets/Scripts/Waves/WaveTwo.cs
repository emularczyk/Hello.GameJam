using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTwo : MonoBehaviour
{
    private DogHutEnemy dogHutEnemy;
    private Spawn spawn;
    [SerializeField] private bool right;
    private static bool waitAllLeft = false; // static dotyczy tej klasy!
    private static bool waitAllRight = false;

    // Start is called before the first frame update
    void Start()
    {
        dogHutEnemy = this.GetComponent<DogHutEnemy>();
        spawn = GameObject.Find("GameManager").GetComponent<Spawn>();
        if (!right)
        {
            dogHutEnemy.invert = !dogHutEnemy.invert;
        }
    }

    // Update is called once per frame
    void Update()
    {
       rotate();
       if (waitAllLeft)
            dogHutEnemy.freezeMovement();
    
       if (waitAllRight)
            dogHutEnemy.freezeMovement();
    }

void rotate()
    {
        if (right)
        {
            if ((transform.position.x < (spawn.leftWall - 3.3f)) && dogHutEnemy.invert == false)
            {
                dogHutEnemy.invert = !dogHutEnemy.invert;
                StartCoroutine(WaitAllRight());
            }
        }
        else
        {
            if ((transform.position.x > (spawn.rightWall + 3.3f)) && dogHutEnemy.invert == true)
            {
                dogHutEnemy.invert = !dogHutEnemy.invert;
                StartCoroutine(WaitAllLeft());
            }
        }
    }
    IEnumerator WaitAllRight()
    {
        yield return new WaitForSeconds(20);
        waitAllRight=true;
    }

    IEnumerator WaitAllLeft()
    {
        yield return new WaitForSeconds(30);
        waitAllLeft = true;
    }

}
