using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformLever : MonoBehaviour, IInteract
{
    Animator anim;
    [SerializeField] AudioClip KeyClip;
    private bool isUsed = true;
    private MovingPlatform movePlatform;

    public void InteractionObject()
    {
        if (!isUsed) return;
        anim.SetTrigger("DoorKey");
        AudioPool.instance.Play(KeyClip, 1f, 0.5f);
        isUsed = false;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
        movePlatform = GameObject.Find("PlatformTest/Platform").GetComponent<MovingPlatform>();
    }

    public void MovePlatform()
    {
        StartCoroutine(MoveSpeed(1.5f));
    }

    IEnumerator MoveSpeed(float sec)
    {
        yield return new WaitForSeconds(sec);

        movePlatform.speed = 2f;
    }
}
