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
    [SerializeField] private float sinFreguency;
    [SerializeField] private float sinAmplitude;
    [SerializeField] private bool sinInverted;
    [SerializeField] private bool chase;
    [SerializeField] private bool onSides;
    [SerializeField] private bool invert;

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

    private void FixedUpdate()
    {
        if (chase)
            attack();
        else
            moveDownSin();
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
        float sin = Mathf.Sin(pos.y* sinFreguency)*sinAmplitude;
        if (sinInverted)
            sin *= -1;
        pos.x = ourX+sin* Time.fixedDeltaTime;
        pos.y -= speed * Time.fixedDeltaTime;
        transform.position = pos;
    }
}
