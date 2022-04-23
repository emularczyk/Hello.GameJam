using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowShard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
