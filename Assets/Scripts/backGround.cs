using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    [SerializeField] private float speed;
    private Spawn spawn;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.Find("GameManager").GetComponent<Spawn>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime);
        if(transform.position.y < spawn.bottomWall-5)
        {
            transform.position = new Vector3(transform.position.x, spawn.bottomWall + 18);
        }
    }
}
