using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Start : MonoBehaviour // start 버튼을 누르면 씬이 변경 되도록 한 스크립트
{
    [SerializeField] private AudioClip startButtonSound;
    [SerializeField] private AudioClip exitButtonSound;
    [SerializeField] private Image image;
    [SerializeField] Transform teleportPos;
    [SerializeField] private Image panel;
    MirrorBlock mirrorBlock;
    [SerializeField] private Transform playerPos;

    private float fadeAlpha = 0f;

    private void Awake()
    {
        mirrorBlock = FindObjectOfType<MirrorBlock>();
    }

    public void Start_2()
    {
        StartCoroutine(ButtonSound());
    }

    public void Exit()
    {
        StartCoroutine(ButtonSound_1());
    }

    public void Retry()
    {
        panel.gameObject.SetActive(false);
        GameManager.playerTimeScale = 1f;
        Time.timeScale = 1f;
        mirrorBlock.Reset();
        StartCoroutine(Fade());
    }

    IEnumerator ButtonSound()
    {
        AudioPool.instance.Play(startButtonSound, 1f, 2f);

        yield return new WaitForSecondsRealtime (0.4f);
        CursorManager.instance.CursorSet(CursorType.NoneCursor);
        SceneManager.LoadScene(1);
    }

    IEnumerator ButtonSound_1()
    {
        AudioPool.instance.Play(exitButtonSound, 1f, 0.4f);
        
        yield return new WaitForSecondsRealtime(0.5f);

        Application.Quit();
    }
    IEnumerator Fade()
    {
        while (fadeAlpha <= 1f)
        {
            fadeAlpha += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeAlpha);
        }
        if(fadeAlpha >= 1f)
        {
            playerPos.position = teleportPos.position;  
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        fadeAlpha = 1f;        
        while (fadeAlpha >= 0)
        {
            fadeAlpha -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeAlpha);
        }
    }
}
