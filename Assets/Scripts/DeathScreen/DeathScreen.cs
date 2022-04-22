using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void QuitButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game");
    }
}
