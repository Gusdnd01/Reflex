using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour //NPC들이 말하는거 만들었어요. 
{
    Dictionary<int, string[]> TalkData;
    void Awake()
    {
        TalkData = new Dictionary<int, string[]>();
        GenerateData();
    }


    void GenerateData()
    {
        TalkData.Add(1000, new string[] { "반갑습니다.", $"이곳은 세계최대의 거울 공장 \n \t\t 미러리 입니다.", "방문을 환영합니다." });

        TalkData.Add(1001, new string[] { "도대체 무슨일이 있었던걸까?", "세상이 어두워 보여… 너도 그러니 ?" });

        TalkData.Add(1002, new string[] { "삐- 리- 삐리리-- -이상무?" });

        TalkData.Add(1003, new string[] { "저는 거울속에 제가 너무 좋아요" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == TalkData[id].Length)
            return null;
        else
            return TalkData[id][talkIndex];
    }
}
