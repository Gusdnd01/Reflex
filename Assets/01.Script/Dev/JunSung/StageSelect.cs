using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class StageSelect : MonoBehaviour
{
    private Canvas canvas;
    private GameObject pointImg;
    private GameObject startPanel;
    private GameObject selectPanel;
    private Image fadePanelImage;
    private GameObject fadePanel;
    private Button selectBtn;
    private GameObject StageBtn = null;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        startPanel = canvas.transform.Find("StartPanel").gameObject;
        selectPanel = canvas.transform.Find("SelectPanel").gameObject;
        selectBtn = selectPanel.transform.Find("SelectBtn").GetComponent<Button>();
        pointImg = selectPanel.transform.Find("PointImage").gameObject;
        fadePanelImage = canvas.transform.Find("FadePanel").GetComponent<Image>();
        fadePanel = canvas.transform.Find("FadePanel").gameObject;

    }

    public void OpenSelectScrene()
    {
        startPanel.SetActive(false);
        selectPanel.SetActive(true);
        selectBtn.interactable = false;
    }
    /// <summary>
    /// 스테이지 선책창 열기
    /// </summary>
    public void SelectStage()
    {
        StageBtn = EventSystem.current.currentSelectedGameObject;
        pointImg.transform.position = StageBtn.transform.position;
        pointImg.SetActive(true);
        selectBtn.interactable = true;
    }
    /// <summary>
    /// 스테이지 선택
    /// </summary>
    public void OpenStage()
    {
        fadePanel.SetActive(true);
        fadePanelImage.DOFade(1, 0.5f).OnComplete(() => SceneManager.LoadScene(StageBtn.name));
    } 
}
