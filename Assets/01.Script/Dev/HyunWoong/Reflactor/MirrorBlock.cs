using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorBlock : HitAbleObject
{
    public int attackCount = 4;
    [SerializeField] private Image[] image;
    [SerializeField] private Sprite change;
    [SerializeField] private Sprite reset;
    public int index = 0;

    public override void Hit()
    {
        if (attackCount > 0)
        {
            attackCount--;
            transform.Rotate(Vector3.forward, 90f);
            ImageChange.Instance.Hit(image[index], change);
            index++;
        }
    }

    public void Reset()
    {
        index = 0;
        attackCount = 4;
        for(int i = 0; i < image.Length; i++)
        {
            image[i].sprite = reset;
        }
    }

    public override void Hit_Right()
    {
        
    }
}
