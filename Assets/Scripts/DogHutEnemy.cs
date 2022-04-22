using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHutEnemy : Enemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reload;
    [SerializeField] private float breakTime;
    public int booletSeries;

    public Animator anim;


    // nie potrafiê odziedziczyæ i rozszerzyæ start()
    void Awake()
    {
        StartCoroutine(BreakWait());
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    IEnumerator BreakWait()
    {
        yield return new WaitForSeconds(breakTime);
        anim.SetBool("DogIn", true);
        StartCoroutine(Fire(booletSeries));
    }

    private void Move()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (transform.position.y < -6)
            Destroy(this.gameObject);
    }

    IEnumerator Fire(int number)
    {
        yield return new WaitForSeconds(reload);
        for (int i=0;i<number;i++)
        {
            yield return new WaitForSeconds(reload);
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
        anim.SetBool("DogIn", false);
        StartCoroutine(BreakWait());
    }
}
