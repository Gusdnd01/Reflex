using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
public class Eventy : MonoBehaviour
{
    [SerializeField] private UnityEvent unityEvent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        unityEvent?.Invoke();   
    }
}
