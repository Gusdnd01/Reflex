using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField] private GameObject poolObject;
    [SerializeField] private Transform content, hip;
    [SerializeField] private Queue<GameObject> poolQueue = new Queue<GameObject>();//이건 큐
    public void Start()
    {
        for (int i = 0; i < 3; i++)//기본값 설정하기
        {
            GameObject obj = Instantiate(poolObject, content);
            obj.name = $"Object {i}";
            obj.SetActive(false);
            poolQueue.Enqueue(obj);
        }
        StartCoroutine(Pool());
    }
    IEnumerator Pool()//꺼내오기
    {
        while (true)
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.F));
            GameObject obj;
            if (poolQueue.Count != 0)//Queue 가 안비어있을 때
            {
                obj = poolQueue.Dequeue();//코드상으로 빼주기(Queue 자료구조)
            }
            else
            {
                obj = Instantiate(poolObject, content);//없으니까 생성하기
                poolQueue.Enqueue(obj);
            }
            obj.SetActive(true);//오브젝트 켜주기
            obj.transform.SetParent(hip);
            StartCoroutine(DePool(obj));
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator DePool(GameObject obj)//넣어주기
    {
        yield return new WaitForSeconds(0.5f);
        obj.SetActive(false);//오브젝트 꺼주기
        obj.transform.SetParent(content);
        poolQueue.Enqueue(obj);//코드상으로 넣어주기(Queue 자료구조)
    }
}
