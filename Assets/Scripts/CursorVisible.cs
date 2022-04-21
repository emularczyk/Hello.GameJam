using UnityEngine;

public class CursorVisible : MonoBehaviour
{

    public bool isVisible = true;

    void Update()
    {
        Cursor.visible = isVisible;
    }
}