using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    #region Æ÷Å»
    [SerializeField] protected GameObject ptEnt;
    [SerializeField] protected GameObject ptQui;
    #endregion

    /// <summary>
    /// portal enter
    /// </summary>
    /// <param name="collision"></param>
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            ptEnt = collision.gameObject;
        }
    }

    /// <summary>
    /// portal quit 
    /// </summary>
    /// <returns></returns>
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            StartCoroutine(Teleport());
        }
    }

    /// <summary>
    /// portal move
    /// </summary>
    /// <returns></returns>
    protected IEnumerator Teleport()
    {
        yield return null;
        ptEnt.transform.position = ptQui.transform.position;
    }
}
