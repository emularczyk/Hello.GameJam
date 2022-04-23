using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFirePattern2 : MonoBehaviour
{
    private float angle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
    }

    private void Fire()
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
