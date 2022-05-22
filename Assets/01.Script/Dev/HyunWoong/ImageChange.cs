using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChange : MonoBehaviour
{
    public static ImageChange Instance;
    private void Awake()
    {
        Instance = this;
    }

    public void Hit(Image image, Sprite sprite)
    {
        image.sprite = sprite;
    }
}
