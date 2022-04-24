using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceen : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(ChageScceen());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator ChageScceen()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene("MainMenu");
    }

}
