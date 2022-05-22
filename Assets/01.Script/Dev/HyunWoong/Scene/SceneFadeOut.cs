using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFadeOut : MonoBehaviour
{
    public Image image;
    float fadeAlpha = 1f;

    void Awake()
    {
        StartCoroutine(FadeOut());
        Time.timeScale = 1f;
        GameManager.playerTimeScale = 1f;
    }

    IEnumerator FadeOut()
    {
        print("asdasd");
        while (fadeAlpha >= 0f)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeAlpha);
        }
    }
}
