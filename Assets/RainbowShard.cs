using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowShard : MonoBehaviour
{
    [SerializeField] private GameObject rainbowShard0;
    [SerializeField] private GameObject rainbowShard1;
    [SerializeField] private GameObject rainbowShard2;
    [SerializeField] private GameObject rainbowShard3;
    [SerializeField] private GameObject rainbowShard4;
    [SerializeField] private GameObject rainbowShard5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
