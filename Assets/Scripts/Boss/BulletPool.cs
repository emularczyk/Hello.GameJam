using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet; // represents particular bullet, which is put to the pool
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        // check if there are any bullets in pool already
        if (bullets.Count > 0)
        {
            for(int i=0;i<bullets.Count; i++)
            {
                if(!bullets[i].activeInHierarchy) // find one that's inactive at the moment
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool) // when scene has just started or all of them are used at the moment
        {
            GameObject bul = Instantiate(pooledBullet); // we add some bullets to the pool
            bul.SetActive(false); // set it to inactive state
            bullets.Add(bul); // add it to the pool
            return bul; // return it
        }

        return null;
    }

}
