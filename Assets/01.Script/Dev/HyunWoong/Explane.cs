using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Explane : MonoBehaviour
{
    [SerializeField] private GameObject explaneText;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            explaneText.SetActive(true);

            Sequence seq = DOTween.Sequence();

            seq.Append(explaneText.transform.DOScale(new Vector3(1.2f, 1.2f), 0.2f));
            seq.Append(explaneText.transform.DOScale(new Vector3(0.9f, 0.9f), 0.05f));
            seq.Append(explaneText.transform.DOScale(new Vector3(1f, 1f), 0.05f));
            //seq.Insert(0, explaneText.transform.DORotate(new Vector3(0, 720f, 0), 0.6f, RotateMode.FastBeyond360));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(explaneText.transform.DOScale(new Vector3(1.2f, 1.2f), 0.2f));
        seq.Append(explaneText.transform.DOScale(new Vector3(0.9f, 0.9f), 0.05f));
        seq.Append(explaneText.transform.DOScale(new Vector3(1f, 1f), 0.05f));
        //seq.Insert(0, explaneText.transform.DORotate(new Vector3(0, 720f, 0), 0.6f, RotateMode.FastBeyond360));
        seq.AppendCallback(() => { explaneText.SetActive(false); });
    }
}
