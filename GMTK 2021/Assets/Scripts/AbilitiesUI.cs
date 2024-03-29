﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilitiesUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    public AbilityHolder slot;
    AbilityHolder prevSlot;
    GameObject ability;
    CanvasGroup canvasGroup;
    RectTransform rectTransform;
    Vector2 prevPos;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        prevPos = rectTransform.anchoredPosition;
        canvasGroup.blocksRaycasts = false;
        if (slot)
        {
            prevSlot = slot;
            ability = slot.ability;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        prevSlot.ability = null;
        StartCoroutine(revertPosition());
    }
    IEnumerator revertPosition()
    {
        yield return new WaitForSeconds(0.01f);
        if (!slot.ability)
        {
            rectTransform.anchoredPosition = prevPos;
            prevSlot.ability = ability;
        }
    }
}
