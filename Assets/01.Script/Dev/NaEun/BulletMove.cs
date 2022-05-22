using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;

    public void Start()
    {
        Destroy(gameObject, 3f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
}
