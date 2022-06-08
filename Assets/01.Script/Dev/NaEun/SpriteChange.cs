using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    private float changeDelay = 0.2f;
    public Sprite activeSprite, defaultSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] GameObject hit;
    
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obe"))
        {
            spriteRenderer.sprite = activeSprite;
            StartCoroutine(Back());
        }
    }*/
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obe"))
        {
            spriteRenderer.sprite = activeSprite;
            StartCoroutine(Back());
        }
    }
    IEnumerator Back()
    {
        yield return new WaitForSeconds(changeDelay);
        spriteRenderer.sprite = defaultSprite;
    }
}
