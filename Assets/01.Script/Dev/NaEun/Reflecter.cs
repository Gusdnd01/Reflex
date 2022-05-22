using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Reflecter : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector3 lastVelocity;
    [SerializeField] ParticleSystem tB;
    [SerializeField] private Image image;
    float fadeAlpha = 0f;
    [SerializeField] private Animator anim;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        lastVelocity = rigid.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        print("aa");
        var speed = lastVelocity.magnitude; 
        var dir = Vector2.Reflect(lastVelocity.normalized, collision.contacts[0].normal); 
        rigid.velocity = dir * Mathf.Max(speed, 0f); 

        if(collision.collider.CompareTag("Ground"))
        {
            ParticleSystem ps = Instantiate(tB, transform.position, Quaternion.identity) as ParticleSystem;
            ps.Play();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Key")){
            Destroy(gameObject);
        }
    }
}
