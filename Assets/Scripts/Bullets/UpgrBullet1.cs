using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgrBullet1 : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
