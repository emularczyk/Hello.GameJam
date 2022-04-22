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
        player = GameObject.Find("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        // Following Player
       Vector3 direction = player.position - transform.position;
       float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
       rb.rotation = angle;
       direction.Normalize();
       movement = direction;
    }
    
    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));

    }

}
