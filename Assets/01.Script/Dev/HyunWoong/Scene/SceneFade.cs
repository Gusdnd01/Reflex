using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Image image;
    public GameObject button;

    public void Button()
    {
        button.SetActive(false);
        image.DOFade(1, 1f);
    }
}