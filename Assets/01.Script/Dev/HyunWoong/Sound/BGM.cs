using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField]
    AudioClip m_Clip;

    void Start()
    {
        AudioPool.instance.Play(m_Clip, 1f, 1f);
    }
}
