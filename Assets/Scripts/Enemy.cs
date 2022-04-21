using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    //private int receivedDamage; //musi siê odnosiæ do ataku gracza
    private bool isHit = false;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private int life;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Destroy(this.gameObject);
            }
        }
    }
}
