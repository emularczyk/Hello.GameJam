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
   private Animator anim;
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
        anim = this.GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
        ourY = transform.position.y;
        ourX = transform.position.x;
    }


    // Update is called once per frame

    private void FixedUpdate()
    {
        if (freez==0)
        {
            if (chase)
                attack();
            else
                moveDownSin();
        }
        if (!anim.GetBool("freez") && freez > 0)
        {
            anim.SetBool("freez", true);
            StopAllCoroutines();
            StartCoroutine(Unfreez());
        }

    }

    void attack()
    {
        lokingForPlayer();
        rb.MovePosition((Vector2)transform.position + ( direction * speed * Time.fixedDeltaTime));
        
    }
    IEnumerator Unfreez()
    {
        yield return new WaitForSeconds(freez);
        this.freez -= freez;
        anim.SetBool("freez", false);
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
   
        if (!onSides)
        {
            float sin = Mathf.Sin(pos.y * sinFreguency) * sinAmplitude;
            if (sinInverted)
                sin *= -1;
            pos.x = ourX + sin * Time.fixedDeltaTime;
            pos.y -= speed * Time.fixedDeltaTime;
        }
        else
        {
            float sin = Mathf.Sin(pos.x * sinFreguency) * sinAmplitude;
            if (sinInverted)
                sin *= -1;
            pos.y = ourY + sin * Time.fixedDeltaTime;
            pos.x -= speed * Time.fixedDeltaTime;
            
        }

        transform.position = pos;
    }
}
