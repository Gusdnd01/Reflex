using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Transform TeleportPos;

    [SerializeField]
    AudioClip teleportSound;

    public void Tele()
    {
        FadeManager.Instance.FadeIn();
        StartCoroutine(DelayTeleport(1f));
    }

    IEnumerator DelayTeleport(float sec)
    {
        yield return new WaitForSeconds(sec);
        AudioPool.instance.Play(teleportSound, 1f, 3f);
        Player.position = TeleportPos.position;
        yield return new WaitForSeconds(sec);
        FadeManager.Instance.FadeOut();
    }
}
