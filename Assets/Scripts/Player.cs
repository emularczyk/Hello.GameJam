using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float speed;

    private GameObject Bullet;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rb;
    private Animator animCharger;
    private Animator anim;


    private int chage;
    [SerializeField] private float rechargeTime;

    // Life and Knockdown
    [SerializeField] private float knockdown;
    private bool isHit = false;
    [SerializeField] private int life; //as int
    [SerializeField] LifeSystem lifeVisible; //total player life seen on canvas

    [SerializeField] Spawn spawn;

    // Attack
    [SerializeField] private Bullet[] attackTypes;
    [SerializeField] private int rainbowFragments = 0;
    int attackNumber = 0;

    private void Start()
    {
        lifeVisible = GameObject.Find("GameManager").GetComponent<LifeSystem>();
        StartCoroutine(chargeCannon());
        animCharger = GameObject.Find("ChargedBoolets_0").GetComponent<Animator>();
        animCharger.SetInteger("color",0);
        anim=this.GetComponent<Animator>();
        spawn = GameObject.Find("GameManager").GetComponent<Spawn>();
    }

    private void Update()
    {
        movement();
        if (chage >= 10 &&  Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(attackNumber+6);
            animCharger.SetBool("Charged", false);
            chage = 0;
        }
        else if( Input.GetKeyDown(KeyCode.Space))
        {
            chage = 0;
            Shoot(attackNumber);
        }
    }

    private void ChageBoolet(int type)
    {
        attackNumber= type;
        animCharger.SetInteger("color", type);
    }
    private void Shoot(int attackType)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(attackTypes[attackType], transform.position, Quaternion.identity);
        }
    }
    IEnumerator chargeCannon()
    {
        yield return new WaitForSeconds(rechargeTime);
        chage++;
        if (chage >= 10)
            animCharger.SetBool("Charged", true);
        else
        {
            animCharger.SetBool("Charged", false);
        }
        StartCoroutine(chargeCannon());
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBullet")
        {
            Hurt();
        }
        if (other.gameObject.CompareTag("RainbowShard"))
        {
            rainbowFragments++;
            anim.SetTrigger("rainbow");
            if (rainbowFragments < 5)
            {
                spawn.RainbowShardsTexts[rainbowFragments].gameObject.SetActive(false);
            }
        }
    }
    public void Hurt()
    {
        if (isHit == false)
        {
            life--;
            if (life < 1)
            {
                lifeVisible.UpdateLife(life);
                Destroy(this.gameObject);
            }
            StartCoroutine(ResetPlayer());

            lifeVisible.UpdateLife(life);
        }
    }
    IEnumerator ResetPlayer()
    {
        isHit = true;
        chage = 0;
        animCharger.SetBool("Charged", false);
        sprite.enabled = false;
        yield return new WaitForSeconds(knockdown);
        sprite.enabled = true;
        yield return new WaitForSeconds(knockdown);
        sprite.enabled = false;
        yield return new WaitForSeconds(knockdown);
        sprite.enabled = true;
        yield return new WaitForSeconds(knockdown);
        sprite.enabled = false;
        yield return new WaitForSeconds(knockdown);
        sprite.enabled = true;
        chage = 0;
        isHit = false;
    }
    void movement()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && rb.position.x > -8.4) //dziala
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && rb.position.x < 8.4) 
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && rb.position.y > -4.3)
        {
            transform.Translate(new Vector3(0, -speed  * Time.deltaTime, 0));
        }
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && rb.position.y < 4.3)
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }



}
