using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeySpriteChange : MonoBehaviour
{
    Animator anim;
    private float fadeAlpha = 0;
    [SerializeField] private Image image;
    [SerializeField] private Animator wayAnimation;
    [SerializeField] private Animator wayAnimation_1;
    [SerializeField] private Animator wayAnimation_2;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        anim.SetTrigger("Open");

        CameraManager.instance.SetOpenCam();

        StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        yield return new WaitForSeconds(2f);
        wayAnimation.SetTrigger("DoorOpen");
        wayAnimation_1.SetTrigger("DoorOpen");
        wayAnimation_2.SetTrigger("DoorOpen");
    }
}
