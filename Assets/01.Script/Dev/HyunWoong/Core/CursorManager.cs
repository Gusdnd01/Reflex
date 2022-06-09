using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CursorManager : MonoBehaviour
{
    public static CursorManager instance;
    [SerializeField] private Texture2D cursorTexture_Clicked;
    [SerializeField] private Texture2D cursorTexture_Default;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Error!");
        }
    }

    public void CursorSet(CursorType type)
    {
        switch (type)
        {
            case CursorType.ClickedCursor:
                //Vector2 pivot;
                //pivot.x = cursorTexture_Clicked.texelSize.x;
                //pivot.x = cursorTexture_Clicked.texelSize.x;
                Cursor.SetCursor(cursorTexture_Clicked, Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.DefaultCursor:
                Cursor.SetCursor(cursorTexture_Clicked, Vector2.zero, CursorMode.ForceSoftware);
                break;
            case CursorType.NoneCursor:
                Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
                break;
            default:
                break;
        }
    }
    [ContextMenu("셋 클릭")]
    public void SetClick()
    {
        CursorSet(CursorType.ClickedCursor);
    }
    [ContextMenu("셋 기본")]
    public void SetDefalut()
    {
        CursorSet(CursorType.DefaultCursor);
    }
    [ContextMenu("논")]
    public void None()
    {
        CursorSet(CursorType.NoneCursor);
    }
}
public enum CursorType
{
    ClickedCursor,
    DefaultCursor,
    NoneCursor
}