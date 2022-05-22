using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        CursorManager.instance.CursorSet(CursorType.DefaultCursor);
    }
}
