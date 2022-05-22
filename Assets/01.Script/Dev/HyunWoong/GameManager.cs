using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Camera cam;
    public Transform player;
    public static float playerTimeScale = 1;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("instance is not null");
        }
        instance = this;

        cam = Camera.main;
    }
}
