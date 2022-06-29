using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    #region ��Ż
    [SerializeField] protected GameObject ptEnt;
    [SerializeField] protected GameObject ptQui;
    #endregion

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
            ptEnt = collision.gameObject;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
            StartCoroutine(Teleport());
    }

    /// <summary>
    /// ���� �̵� �Լ�
    /// </summary>
    /// <returns></returns>
    protected IEnumerator Teleport()
    {
        yield return null;
        ptEnt.transform.position = ptQui.transform.position;
    }
}
