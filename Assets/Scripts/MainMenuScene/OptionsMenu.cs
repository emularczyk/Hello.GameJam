using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public void setFullScreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
