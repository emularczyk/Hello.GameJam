using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveTwo : MonoBehaviour
{
    private DogHutEnemy dogHutEnemy;
    private Spawn spawn;
    [SerializeField] private bool right;
    private static bool waitAll = false; // static dotyczy tej klasy!

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
       if(waitAll)
            dogHutEnemy.freezeMovement();
    }

    void rotate()
    {
        if (right)
        {
            if ((transform.position.x < (spawn.leftWall - 3.3f)) && dogHutEnemy.invert == false)
            {
                dogHutEnemy.invert = !dogHutEnemy.invert;
                StartCoroutine(WaitAll());
            }
        }
        else
        {
            if ((transform.position.x > (spawn.rightWall + 3.3f)) && dogHutEnemy.invert == true)
            {
                dogHutEnemy.invert = !dogHutEnemy.invert;
                StartCoroutine(WaitAll());
            }
        }
    }
    IEnumerator WaitAll()
    {
        yield return new WaitForSeconds(15);
        waitAll=true;
    }

}
