using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerRendere;
    private Transform player;
    bool isCanFlip = true;
    Camera cam;

    void Start()
    {
        player = transform.GetComponentInParent<Transform>();
        cam = GameManager.instance.cam;
    }

    void Update()
    {
        if(!isCanFlip)
        {
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    public void FlipHandle(bool isCancle)
    {
        isCanFlip = !isCancle;
    }
}
