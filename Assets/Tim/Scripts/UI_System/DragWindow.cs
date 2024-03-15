using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragWindow : MonoBehaviour, IDragHandler
{
    [SerializeField] private RectTransform dragRectTransform;
    [SerializeField] private Transform originalPosition;
    public void OnDrag(PointerEventData eventData)
    {
        dragRectTransform.anchoredPosition += eventData.delta;
    }

    public void ResetPosition()
    {

    }
}
