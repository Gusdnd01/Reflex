using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObeHit : HitAbleObject
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;
    Action action;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMove>().transform;
    }
    public override void Hit()
    {
        if(player.transform.position.x - transform.position.x < 0)
        {
            rb.velocity = Vector2.right * 6;
        }
        else
        {
            rb.velocity = Vector2.left * 6;
        }
    }
    public void Set(Action callBack)
    {
        action = callBack;
    }

    private void OnDestroy()
    {
        if (action == null) return;

        action();
    }

    public override void Hit_Right()
    {
        //¾È¾µµí
    }
}
