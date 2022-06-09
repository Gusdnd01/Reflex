using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    #region 포탈
    [SerializeField] protected GameObject ptEnt;
    [SerializeField] protected GameObject ptQui;
    #endregion

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            ptEnt = collision.gameObject;
        }
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            StartCoroutine(Teleport());
        }
    }

    /// <summary>
    /// 오브 이동 함수
    /// </summary>
    /// <returns></returns>
    protected IEnumerator Teleport()
    {
        yield return null;
        ptEnt.transform.position = ptQui.transform.position;
    }
}
