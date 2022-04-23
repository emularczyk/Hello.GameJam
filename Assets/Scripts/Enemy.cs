using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Score score;
    [SerializeField] private int points;
    private Spawn spawn;

    [SerializeField]  private float margines = 3f;

    //private int receivedDamage; //musi si� odnosi� do ataku gracza
    private bool isHit = false;

    [SerializeField] private int life;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
        spawn = GameObject.Find("GameManager").GetComponent<Spawn>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if  (transform.position.y > spawn.topWall + margines || transform.position.y < spawn.bottomWall - margines || transform.position.x < spawn.leftWall - margines || transform.position.x > spawn.rightWall + margines)
            Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Hurt();
        }
    }

    public void Hurt()
    {
        if (isHit == false)
        {
            life--;
            // life -= receivedDamage;
            if (life < 1)
            {
                score.UpdateScore(points);
                Destroy(this.gameObject);
            }
        }
    }

}
