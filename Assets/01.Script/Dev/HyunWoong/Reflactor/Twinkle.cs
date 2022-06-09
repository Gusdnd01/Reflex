using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Twinkle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DT());
    }

    IEnumerator DT()
    {
        

        while (true)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(gameObject.transform.DOScale(new Vector2(1f, 1f), 0.8f));       
            seq.Append(gameObject.transform.DOScale(new Vector2(1.1f, 1.1f), 0.8f));       
            seq.Append(gameObject.transform.DOScale(new Vector2(1f, 1f), 0.8f));       

            yield return new WaitForSeconds(1f);
        }
    }
}
