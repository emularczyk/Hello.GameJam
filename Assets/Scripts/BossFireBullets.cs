using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireBullets : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 90f, endAngle = 270f; // allows us to adjust the sector in which our bullets will be spread

    private Vector2 bulletMoveDirection;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f); // fire every 2 seconds
        InvokeRepeating("Fire", 0f, 1.5f);
        InvokeRepeating("Fire", 0f, 1f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount; // we want bullets to spread proportionally in the sector
        float angle = startAngle; // angle is used to calculate bulletMoveDirection

        // to calculate direction vector, we need to calculate coordinates:
        for(int i=0; i<bulletsAmount +1; i++)
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

}
