using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrBullet0 : MonoBehaviour
{
    private SpriteRenderer sprite;
    public int dmg;
    public float speed;

    protected virtual void Start()
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
        if (transform.position.y > 6.41)
            Destroy(this.gameObject);
    }
}
