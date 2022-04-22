using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoves : MonoBehaviour
{
    private float ourY;
    private float ourX;
    [SerializeField] private float freguency;
    [SerializeField] private float amplitude;
    [SerializeField] private bool inverted;

    // Start is called before the first frame update
    void Start()
    {
        ourY = transform.position.y;
        ourX = transform.position.x;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MoveSiny();
    }
    public void MoveSinx()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.x * freguency) * amplitude;
        pos.y = ourY + sin;
        if (inverted)
            sin *= -1;
        transform.position = pos;
    }
    public void MoveSiny()
    {
        Vector2 pos = transform.position;
        float sin = Mathf.Sin(pos.y * freguency) * amplitude;
        pos.x = ourX + sin;
        if (inverted)
            sin *= -1;
        transform.position = pos;
    }
}
