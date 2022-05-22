using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExinToESC : MonoBehaviour
{
    [SerializeField]
    Image image;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            image.DOFade(1f, 1f);

            StartCoroutine(Exit(3));
        }
    }

    IEnumerator Exit(int sec)
    {
        yield return new WaitForSeconds(sec);

        Application.Quit();
    }
}
