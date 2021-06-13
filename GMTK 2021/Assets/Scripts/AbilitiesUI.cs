using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilitiesUI : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Canvas canvas;
    public AbilityHolder slot;
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
        if(slot) slot.ability = null;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        StartCoroutine(revertPosition());
    }
    IEnumerator revertPosition()
    {
        yield return new WaitForSeconds(0.01f);
        if (!slot.ability) rectTransform.anchoredPosition = prevPos;
    }
}
