using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour //특정 키를 눌렀을때 이미지가 바뀌는거 만들었습니다
{
    public int curState;
    public Image image;
    public Sprite changer;
    bool isChange = true;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && isChange == true) //Esc키 눌렀을때 적용되지 않도록 하는거에요 
        {
            isChange = false;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && isChange == false)
        {
            isChange = true;
        }
        
        if(Input.GetMouseButtonDown(0) && isChange == true)
        {
            Change();
        }
    }
    public void Change()
    {
        image.sprite = changer;
    }
}