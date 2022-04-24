using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMainMenu : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(ChangeMenu());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    IEnumerator ChangeMenu()
    {
        yield return new WaitForSeconds(18);
        LoadMenu();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
