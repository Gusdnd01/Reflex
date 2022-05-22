using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class NPC : MonoBehaviour, IInteract
{
    bool isUsing;
    public bool isAfterUse = false;
    public GameObject TextMessage { get{ return textMessage; } }
    [SerializeField] private GameObject textMessage;
    [SerializeField] private GameObject textImage;
    [SerializeField] private NPCManager manager;
    [SerializeField] private DialogFollow textDisplayManager;
    [SerializeField] private AudioClip npcClip;
    [SerializeField] private GameObject Interaction;

    PlayerMove playerMove;
    public DialogFollow TextDisplayManager { get { return textDisplayManager; } }

    void Awake() => playerMove = FindObjectOfType<PlayerMove>();//transform.Find("player_0").GetComponent<PlayerMove>();
    
    public void InteractionObject()
    {
        if (!isUsing)
        {
            CameraManager.instance.SetNpcCamActive();
            AudioPool.instance.Play(npcClip, 1f, 1f);
            Interaction.SetActive(false);

            GameManager.playerTimeScale = 0;
            textMessage.SetActive(true);
            textImage.SetActive(true);
            manager.Action(gameObject);
            if(playerMove.count == 4)
            {
                isUsing = true;
                playerMove.count = 0;
                
            }
            
        }
        else
        {
            CameraManager.instance.SetPlayerCamActive();
            GameManager.playerTimeScale = 1;
            Interaction.SetActive(false);

            Sequence seq = DOTween.Sequence();

            seq.Append(Interaction.transform.DOScale(new Vector3(1.2f, 1.2f), 0.2f));
            seq.Append(Interaction.transform.DOScale(new Vector3(0.9f, 0.9f), 0.05f));
            seq.Append(Interaction.transform.DOScale(new Vector3(0.75f, 0.75f), 0.05f));

            isUsing = true;
            isAfterUse = true;
            playerMove.isAfterTalk = true;
            textMessage.SetActive(false);
            textImage.SetActive(false);
        }
    }
}