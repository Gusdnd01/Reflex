using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StageExplain : MonoBehaviour
{
    [SerializeField] private RectTransform stageExplain;
    bool isInteract = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isInteract == false)
        {
            stageExplain.gameObject.SetActive(true);
            isInteract = true;

            Sequence seq = DOTween.Sequence();

            seq.Append(stageExplain.DOAnchorPosY(250, 0.3f));
            seq.Append(stageExplain.DOAnchorPosY(150, 0.6f));
            seq.Append(stageExplain.DOAnchorPosY(200, 0.2f));

            StartCoroutine(TextGone(2f));
            //seq.Insert(0, explaneText.transform.DORotate(new Vector3(0, 720f, 0), 0.6f, RotateMode.FastBeyond360));
        }
    }

    IEnumerator TextGone(float sec)
    {

        yield return new WaitForSeconds(sec);
        stageExplain.DOAnchorPosY(-1000, 0.5f);
    }
}
