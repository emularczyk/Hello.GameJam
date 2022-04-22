using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
        }
        rb = this.GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {  // Following Player
       Vector3 direction = player.position - transform.position;
       float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       direction.Normalize();
       movement = direction;
        }
    }
    
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        /* Vector2 pos = transform.position;
         pos.x -= speed * Time.fixedDeltaTime;
         transform.position = pos;*/

        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.fixedDeltaTime));
        
    }

}
