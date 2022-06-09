using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadeManager : MonoBehaviour
{
    public static FadeManager Instance;

    public RectTransform fadePanelTrm;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple Instance is running");
        }
        Instance = this;
    }

    /// <summary>
    /// È­¸é ±î¸ÅÁü
    /// </summary>
    public void FadeIn()
    {
        Image img = fadePanelTrm.GetComponent<Image>();

        img.DOFade(1, 0.5f);
    }

    /// <summary>
    /// È­¸é ¹à¾ÆÁü
    /// </summary>
    public void FadeOut()
    {
        Image img = fadePanelTrm.GetComponent<Image>();

        img.DOFade(0, 0.5f);
    }
}
