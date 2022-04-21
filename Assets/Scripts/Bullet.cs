using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private SpriteRenderer sprite;

    public float speed;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime / Time.timeScale);
        if (transform.position.y > 4.41)
            Destroy(this.gameObject);
    }
}
