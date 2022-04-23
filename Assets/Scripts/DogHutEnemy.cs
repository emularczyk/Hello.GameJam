using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogHutEnemy : Enemy
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float reload;
    [SerializeField] private float breakTime;
    public int booletSeries;
    public bool onSides;
    public bool invert;

    public Animator anim;

    void Awake()
    {
        StartCoroutine(BreakWait());
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();
    }

    IEnumerator BreakWait()
    {
        yield return new WaitForSeconds(breakTime+Random.Range(0,1));
        anim.SetBool("DogIn", true);
        StartCoroutine(Fire(booletSeries));
    }

    private void Move()
    {   if(onSides)
            transform.Translate(Vector2.left * speed*(invert ? -1:1) * Time.deltaTime);
        else
            transform.Translate(Vector2.down * speed * (invert ? -1 : 1) * Time.deltaTime);
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

    public void freezeMovement()
    {
        speed = 0;
    }

}
