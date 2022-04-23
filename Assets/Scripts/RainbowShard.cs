using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowShard : MonoBehaviour
{
    [SerializeField]  private int speed=1;
    [SerializeField] private Spawn spawn;
    void Start()
    {
        spawn= GameObject.Find("GameManager").GetComponent<Spawn>();
    }
    void Update()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.down *speed* Time.deltaTime / Time.timeScale);
        if (transform.position.y <1)
            speed = 0;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spawn.isReady = true;
            Destroy(this.gameObject);
        }
    }
}
