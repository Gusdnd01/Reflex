using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject ptEnt;
    [SerializeField] GameObject ptEsc;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            ptEnt = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            StartCoroutine(Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return null;
        ptEnt.transform.position = ptEsc.transform.position;
    }
}
