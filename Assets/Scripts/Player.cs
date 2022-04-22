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
    private int rainbowFragments = 0;
    int attackNumber = 0;
    /*syf do ataku
    DateTime start;
    DateTime end;
    TimeSpan t;
    int diff;
    */

    private void Start()
    {

    }
 
    private void Update()
    {
        movement();
        // start = DateTime.Now; //syf do ataku
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attackNumber++;
            if (attackNumber > rainbowFragments)
                    attackNumber = 0;
            Shoot(attackNumber);
        }
    }
    private void Shoot(int attackNumber)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(attackTypes[attackNumber], transform.position, Quaternion.identity);

            /* syf do ataku
            print(start);
            end = DateTime.Now;
            print(end);
            diff = (int)end.Subtract(start).TotalSeconds;
            print(t);
            print(diff);
            if (rainbowFragments == 0)
            {
                Instantiate(attackTypes[0], transform.position, Quaternion.identity);
            }
            else if (rainbowFragments > 0 && diff < 1)
            {
                Instantiate(attackTypes[0], transform.position, Quaternion.identity);
            }
            else if(rainbowFragments >= 1 && diff < 2)
            {
                Instantiate(attackTypes[1], transform.position, Quaternion.identity);
            }
            else if (rainbowFragments >= 2 && diff < 3)
            {
                Instantiate(attackTypes[2], transform.position, Quaternion.identity);
            }
            else if (rainbowFragments >= 3 && diff < 4)
            {
                Instantiate(attackTypes[3], transform.position, Quaternion.identity);
            }
            else if (rainbowFragments >= 4 && diff < 5)
            {
                Instantiate(attackTypes[4], transform.position, Quaternion.identity);
            }
            else if (rainbowFragments >= 5 && diff < 6)
            {
                Instantiate(attackTypes[5], transform.position, Quaternion.identity);
            }
            */
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

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
