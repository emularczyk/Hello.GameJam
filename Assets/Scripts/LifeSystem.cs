using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    // public GameObject[] hearts; //mo¿na to wsadziæ do tablicy wszystko
    [SerializeField] private Image heartFull1;
    [SerializeField] private Image heartFull2;
    [SerializeField] private Image heartFull3;
    [SerializeField] private Image heartEmpty1;
    [SerializeField] private Image heartEmpty2;
    [SerializeField] private Image heartEmpty3;

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
        print("loop start");
        if (lives == 2)
        {
            heartFull3.enabled = false;
            heartEmpty3.enabled = true;
        }
        if (lives == 1)
        {
            heartFull2.enabled = false;
            heartEmpty2.enabled = true;
        }
        if (lives < 1)
        {
            heartFull1.enabled = false;
            heartEmpty1.enabled = true;
        }
    }
}
