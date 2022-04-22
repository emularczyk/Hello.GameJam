using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : Enemy
{
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 direction;
    private float ourY;
    private float ourX;
    [SerializeField] private float freguency;
    [SerializeField] private float amplitude;
    [SerializeField] private bool inverted;

    // Start is called before the first frame update
    void Awake()
    {
        if (GameObject.Find("Player") != null)
        {
            player = GameObject.Find("Player").GetComponent<Transform>();
        }
        rb = this.GetComponent<Rigidbody2D>();
        ourY = transform.position.y;
        ourX = transform.position.x;
    }


    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        attack();
    }

    void attack()
    {
        lokingForPlayer();
        rb.MovePosition((Vector2)transform.position + ( direction * speed * Time.fixedDeltaTime));
        
    }
    public void lokingForPlayer()
    {
        if (player != null)
        {  // Following Player
            direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            direction.Normalize();
            movement = direction;
        }
    }
    void moveDown()
    {
        Vector2 pos = transform.position;
        pos.y -= speed * Time.fixedDeltaTime;
        transform.position = pos;
    }
    void moveDownSin()//freguency=1,amplitude=50
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.y* freguency)*amplitude;
        if (inverted)
            sin *= -1;
        pos.x = ourX+sin* Time.fixedDeltaTime;
        pos.y -= speed * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
