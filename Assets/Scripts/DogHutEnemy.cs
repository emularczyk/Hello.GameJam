using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHutEnemy : Enemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reload;

    // nie potrafiê odziedziczyæ i rozszerzyæ start()
    void Awake()
    {
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -5.61)
            Destroy(this.gameObject);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(reload);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
