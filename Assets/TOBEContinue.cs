using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TOBEContinue : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    private Image image;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Open");

        StartCoroutine(TobeContinueSceneMove());
    }

    IEnumerator TobeContinueSceneMove()
    {
        float fadeAlpha = 0f;
        while (fadeAlpha <= 1f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);

            image.color = new Color(0, 0, 0, fadeAlpha);
        }
        if(fadeAlpha >= 1f)
        {
            SceneManager.LoadScene(2);
        }
    }
}
