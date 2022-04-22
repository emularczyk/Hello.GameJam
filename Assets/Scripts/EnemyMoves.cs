using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    private float ourY;
    [SerializeField] private float freguency;
    [SerializeField] private float amplitude;
    [SerializeField] private bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        ourY = transform.position.y;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveSin();
    }
    public void MoveSin()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * freguency) * amplitude;
        pos.y = ourY + sin;
        if (inverted)
            pos *= -1;
        transform.position = pos;
    }
}
