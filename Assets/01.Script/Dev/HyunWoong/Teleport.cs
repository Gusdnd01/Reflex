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
        AudioPool.instance.Play(teleportSound, 1f, 3f);
        Player.position = TeleportPos.position;
    }
}
