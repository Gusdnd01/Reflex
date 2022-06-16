using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(oMEGAlEGENDARYcUBE());
    }
    IEnumerator oMEGAlEGENDARYcUBE()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            Instantiate(gameObject, transform);
            gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
        }
    }
}
