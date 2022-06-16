using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    private Canvas canvas;
    private GameObject pointImg;
    private GameObject startPanel;
    private GameObject selectPanel;
    private Button selectBtn;
    private GameObject StageBtn = null;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        startPanel = canvas.transform.Find("StartPanel").gameObject;
        selectPanel = canvas.transform.Find("SelectPanel").gameObject;
        selectBtn = selectPanel.transform.Find("SelectBtn").GetComponent<Button>();
        pointImg = selectPanel.transform.Find("PointImage").gameObject;

    }

    public void OpenSelectScrene()
    {
        startPanel.SetActive(false);
        selectPanel.SetActive(true);
        selectBtn.interactable = false;
    }

    public void SelectStage()
    {
        StageBtn = EventSystem.current.currentSelectedGameObject;
        pointImg.transform.position = StageBtn.transform.position;
        pointImg.SetActive(true);
        selectBtn.interactable = true;
    }

    public void OpenStage()
    {
        SceneManager.LoadScene(StageBtn.name);
    } 
}
