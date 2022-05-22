using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCManager : MonoBehaviour //NPC가 Rayhit 안에 있고 F를 누르면 실행 됩니다
{
    public TalkManager talkManager;
    public GameObject talkPanel;
    public TypeEffect talktext;
    public GameObject scanNPC;
    public bool isAction;
    public int talkIndex;


    public void Action(GameObject scanNPC2)
    {
        scanNPC = scanNPC2;
        NPCData nPCData = scanNPC.GetComponent<NPCData>();
        NPC npc = scanNPC.GetComponent<NPC>();
        Talk(nPCData.id, nPCData.isNpc, npc);
        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNPC, NPC npc)
    {
        print($"Talk : {id} , IsNpc : {isNPC}");
        string talkData = talkManager.GetTalk(id, talkIndex);
        //npc.TextDisplayManager.dia
        //talktext.GetComponent<DialogFollow>().predialog = npc.TextMessage;
        npc.TextDisplayManager.SetPos(npc.TextDisplayManager.transform.position);
        print(talkData);
        if(talkData == null)
        {
            talktext.gameObject.SetActive(false);
            print("대화가 끝났어요");
            return;
        }
        else
        {
            talktext.gameObject.SetActive(true);
        }

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }
        if (isNPC)
        {
            talktext.Setmsg(talkData);
        }

        isAction = true;
        talkIndex++;
    }
}
