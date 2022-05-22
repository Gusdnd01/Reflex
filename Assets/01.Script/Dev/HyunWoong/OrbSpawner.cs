using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject orb;

    [SerializeField]
    Vector2 spawnPos;
    [SerializeField]
    int count = 4;

    private void Start()
    {
        SpawnOrb();
    }

    public void SpawnOrb()
    {
        Instantiate(orb, this.transform.position, Quaternion.identity);
    }
}
