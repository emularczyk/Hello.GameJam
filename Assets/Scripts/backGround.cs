using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGround : MonoBehaviour
{
    [SerializeField] private float speed;
    private int bottomWall = -6;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -speed * Time.deltaTime);
        if(transform.position.y < bottomWall-5)
        {
            transform.position = new Vector3(transform.position.x, bottomWall + 18);
        }
    }
}
