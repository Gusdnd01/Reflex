using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Textdo : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();

        StartCoroutine(TextInstantiate(2f, 6f));
    }

    IEnumerator TextInstantiate(float sec, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        text.DOText("Exit to ESC", sec);
    }
}
