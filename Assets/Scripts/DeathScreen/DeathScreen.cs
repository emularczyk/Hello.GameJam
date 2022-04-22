using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void QuitButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("Game");
    }
}
