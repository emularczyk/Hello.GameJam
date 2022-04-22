using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    public Score score;
    [SerializeField] private int points;

    //private int receivedDamage; //musi siê odnosiæ do ataku gracza
    private bool isHit = false;

    [SerializeField] private int life;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (11 < transform.position.y || transform.position.y < -6 || transform.position.x < -8 || transform.position.x > 8)
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
