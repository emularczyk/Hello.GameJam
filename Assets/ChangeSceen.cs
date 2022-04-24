using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceen : MonoBehaviour
{
   

    void OnEnable()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}
