using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class FocusUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private UnityEvent onEnterEvent;
    [SerializeField] private UnityEvent onExitEvent;

    public void OnPointerEnter(PointerEventData eventData)
    {
        onEnterEvent?.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        onExitEvent?.Invoke();
    }
}
