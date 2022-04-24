using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementSideways : MonoBehaviour
{
    public float moveSpeed;
    private bool moveRight;
    private bool moveDown;
    private float angle = 0f;
    [SerializeField] private int bulletsAmount = 10;


    [SerializeField] private int breakTime;
    [SerializeField] private int fireTime;
    [SerializeField] private float fireFrequency;
    [SerializeField] private int fireAroundTime;
    [SerializeField] private float fireAroundFreguency;



    [SerializeField] private float startAngle = 90f, endAngle = 270f; // allows us to adjust the sector in which our bullets will be spread

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2f;
        moveRight = true;
        moveDown = true;
    }
    // Update is called once per frame
    void Update()
    {
            Move();
    }
    private void Move()
    {
        if (moveDown)
        {
            MoveDown();
        } else
            MoveSides();
    }
    private void MoveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed/2 * Time.deltaTime);
        if (transform.position.y <3.5f)
        {
            StartCoroutine(FazeOne());
            moveDown = false;
        }
 
    }
    IEnumerator FazeOne()
    {
        switch(Random.RandomRange(0, 2))
        {
            case (0):
                InvokeRepeating("Fire", 0f, fireFrequency);
                yield return new WaitForSeconds(fireTime);
                CancelInvoke("Fire");
                break;
            case (1):
                InvokeRepeating("FireAround", 0f, fireAroundFreguency);
                yield return new WaitForSeconds(fireAroundTime);
                CancelInvoke("FireAround"); 
                break;
        }
        yield return new WaitForSeconds(breakTime);
        StartCoroutine(FazeOne());
    }
    private void MoveSides()
    {
        if (transform.position.x > 7f) // if reaches right side of the screen
        {
            moveRight = false;
        }
        else if (transform.position.x < -7f) // if reaches left side of the screen
        {
            moveRight = true;
        }
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount; // we want bullets to spread proportionally in the sector
        float angle = startAngle; // angle is used to calculate bulletMoveDirection

        // to calculate direction vector, we need to calculate coordinates:
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            // for reach of the bullets:
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f); // direction vector
            Vector2 bulDir = (bulMoveVector - transform.position).normalized; // direction 

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet(); // get the bullet from pool
            bul.transform.position = transform.position; // set its position
            bul.transform.rotation = transform.rotation; // set its rotation
            bul.SetActive(true);
            bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);

            angle += angleStep;
        }
    }
    private void FireAround()
    {
        // for reach of the bullets:
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f); // direction vector
        Vector2 bulDir = (bulMoveVector - transform.position).normalized; // direction 

        GameObject bul = BulletPool.bulletPoolInstance.GetBullet(); // get the bullet from pool
        bul.transform.position = transform.position; // set its position
        bul.transform.rotation = transform.rotation; // set its rotation
        bul.SetActive(true);
        bul.GetComponent<BossBullet>().SetMoveDirection(bulDir);

        angle += 30f;
    }
}
