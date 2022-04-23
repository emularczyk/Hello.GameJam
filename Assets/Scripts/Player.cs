using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public float speed;

    private GameObject Bullet;
    [SerializeField] private SpriteRenderer sprite;

    // Life and Knockdown
    [SerializeField] private float knockdown;
    private bool isHit = false;
    [SerializeField] private int life; //as int
    [SerializeField] LifeSystem lifeVisible; //total player life seen on canvas

    // Attack
    [SerializeField] private Bullet[] attackTypes;
    [SerializeField] private int rainbowFragments = 0;
    int attackNumber = 0;

    private void Start()
    {
        lifeVisible = GameObject.Find("GameManager").GetComponent<LifeSystem>();
    }

    private void Update()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(attackNumber);
        }
    }
    private void ChageBoolet(int type)
    {
        attackNumber= type;
    }
    private void Shoot(int attackNumber)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(attackTypes[attackNumber], transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Hurt();
        }
        if (other.gameObject.tag == "EnemyBullet")
        {
            Hurt();
        }
        if (other.gameObject.CompareTag("RainbowShard"))
        {
            rainbowFragments++;
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
        isHit = false;
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -speed  * Time.deltaTime, 0));
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
        }
    }

}
