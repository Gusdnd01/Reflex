using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public Image image;
    public GameObject button;
    public float fadeAlpha = 1f;

    public void Button()
    {
        button.SetActive(false);
        Fade_1();
    }

    public void Fade_1()
    {
        StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        while (fadeAlpha <= 1f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeAlpha);
            if(fadeAlpha >= 1f)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}