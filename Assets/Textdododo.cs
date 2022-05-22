using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Textdododo : MonoBehaviour
{

    Text text;
    void Start()
    {
        text = GetComponent<Text>();

        StartCoroutine(TextInstantiate(5f, 2f));
    }

    IEnumerator TextInstantiate(float sec, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        text.DOText("To be continued...", sec);
    }
}
