using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obe : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    
}
