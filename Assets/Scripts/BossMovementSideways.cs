using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementSideways : MonoBehaviour
{
    public float moveSpeed;
    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        moveRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > 7f) // if reaches right side of the screen
        {
            moveRight = false;
        }
        else if(transform.position.x < -7f) // if reaches left side of the screen
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
