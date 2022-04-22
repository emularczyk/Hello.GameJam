using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody2D rb;
    private float rootZ=0;
    private int rotationSpeed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-0.003f,0.003f), Random.Range(0, 0.002f)), ForceMode2D.Impulse);
        rotationSpeed = Random.Range(-300, 300);
    }
    void Update()
    {
        rootZ += Time.deltaTime*rotationSpeed;
        transform.rotation = Quaternion.Euler(0, 0, rootZ);
        if (transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }

}
   
