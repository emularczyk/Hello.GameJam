using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    [SerializeField] protected float freez=0;
    public Score score;
    [SerializeField] protected int points;
    private Monitor monitor;
    protected Spawn spawn;
    bool isDead;

    [SerializeField]  private float margines = 3f;

    //private int receivedDamage; //musi siê odnosiæ do ataku gracza
    protected bool isHit = false;

    [SerializeField] protected int life;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
        monitor = GameObject.Find("GameManager").GetComponent<Monitor>();
        spawn= GameObject.Find("GameManager").GetComponent<Spawn>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if  (transform.position.y > monitor.topWall + margines || transform.position.y < monitor.bottomWall - margines || transform.position.x < monitor.leftWall - margines || transform.position.x > monitor.rightWall + margines)
        {
            spawn.spawnedEnemies--;
            Destroy(this.gameObject);
        }
   
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag=="Green")
        {
            Destroy(other.gameObject);
            Hurt(other.gameObject.GetComponent<Bullet>().dmg);
        }
        if(other.gameObject.tag == "Blue")
        {
           freez+=other.gameObject.GetComponent<BlueBullet>().freez ;
            Destroy(other.gameObject);
            Hurt(other.gameObject.GetComponent<Bullet>().dmg);
        }
        if (other.gameObject.tag == "Explosion")
        {
            Hurt(other.gameObject.GetComponent<Bullet>().dmg);
        }
    }
        protected virtual void Hurt(int receivedDamage)
    {
        if (isHit == false)
        {
            life-= receivedDamage;
            if (life < 1)
            {
                score.UpdateScore(points);
                if(!isDead)
                     spawn.spawnedEnemies--;
                Destroy(this.gameObject);
            }
        }
    }

}
