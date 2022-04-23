using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHomingMissle : MonoBehaviour
{
	public float speed = 5;
	public float rotatingSpeed = 200;
	public GameObject target;

	Rigidbody2D rb;

	// Use this for initialization
	void Start()
	{
		target = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
		point2Target.Normalize();
		float value = Vector3.Cross(point2Target, transform.right).z;
		
		/*
		if (value > 0) {
				rb.angularVelocity = rotatingSpeed;
		} else if (value < 0)
				rb.angularVelocity = -rotatingSpeed;
		else
				rotatingSpeed = 0;
		*/

		rb.angularVelocity = rotatingSpeed * value;
		rb.velocity = transform.right * speed;
	}


	void OnTriggerEnter2D(Collider2D other)
	{
			Destroy(this.gameObject, 0.02f);
	}


	/* WERSJA 1, moze i byloby ok, gdyby spawner dzialal poprawnie (tworzy obiekt od razu na graczu)
    GameObject target;
   // public GameObject explosion;
    public float rotationSpeed = 1f;

    Quaternion rotateToTarget;
    Vector3 dir;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotateToTarget = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotateToTarget, Time.deltaTime * rotationSpeed);
        rb.velocity = new Vector2(dir.x * 2, dir.y * 2); // we set velocity towards our target
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       // Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    */
}
