using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceen : MonoBehaviour
{
    [SerializeField] private string sceen;

    void Start()
    {
        //StartCoroutine(ChageScceen());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene("Game");
        }
    }

    void OnEnable()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    /*
    IEnumerator ChageScceen()
    {
        yield return new WaitForSeconds(18);
        SceneManager.LoadScene(sceen,LoadSceneMode.Single);
    }
    */
}
