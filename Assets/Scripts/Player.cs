using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    [SerializeField] private GameObject Bullet;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private float knockdown;
    private bool isHit = false;
    [SerializeField] private int life; //as int
    [SerializeField] LifeSystem lifeVisible; //total player life seen on canvas

    private void Start()
    {

    }
 
    private void Update()
    {
        movement();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Hurt();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
