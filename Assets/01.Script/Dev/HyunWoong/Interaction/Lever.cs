using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour, IInteract
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Animator anima;

    [SerializeField]
    private Transform lever;

    [SerializeField]
    private AudioClip doorOpenClip;

    [SerializeField]
    private AudioClip KeyClip;

    private bool isUsed = true;

    public void InteractionObject()
    {
        if (!isUsed) return;
        anim.SetTrigger("DoorKey");
        AudioPool.instance.Play(KeyClip, 1f, 0.5f);
        isUsed = false;

    }

    public void DoorOpen()
    {
        DoorOpenCam();
        anima.SetTrigger("doorOpen");
    }

    private void DoorOpenCam()
    {
        CameraManager.instance.ShakeCam(2, 0.4f);

        StartCoroutine(DelayChangeToActionCam(1f));
    }

    IEnumerator DelayChangeToActionCam(float sec)
    {
        CameraManager.instance.SetActionCamActive();
        AudioPool.instance.Play(doorOpenClip, 0.3f, 2f);
        yield return new WaitForSeconds(sec);

        CameraManager.instance.SetPlayerCamActive();
    }
}