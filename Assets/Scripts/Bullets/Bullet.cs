using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dmg;
    public float speed;
    [SerializeField] private float margines = 3f;
    private Monitor monitor;

    protected virtual void Start()
    {
        monitor = GameObject.Find("GameManager").GetComponent<Monitor>();
    }
    protected virtual void FixedUpdate()
    {
        Move();
    }
    protected virtual void Move()
    {
        transform.Translate(Vector2.up * speed * Time.fixedDeltaTime / Time.timeScale);
        if (transform.position.y > monitor.topWall + margines || transform.position.y < monitor.bottomWall - margines || transform.position.x < monitor.leftWall - margines || transform.position.x > monitor.rightWall + margines)
        {
            Destroy(this.gameObject);
        }
    }
}
