using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPortal : Portal, IInteract
{
    public void InteractionObject()
    {
        ptEnt.gameObject.SetActive(true);
        ptQui.gameObject.SetActive(true);

        StartCoroutine(Teleport());
    }
}
