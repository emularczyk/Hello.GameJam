using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [SerializeField]private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateLife(int lives)
    {
        if (lives == 2)
        {
            heart3.enabled = false;
        }
        if (lives == 1)
        {
            heart2.enabled = false;
        }
        if (lives < 1)
        {
            heart1.enabled = false;
        }
    }
}
