using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityHolder : MonoBehaviour, IDropHandler
{
    public GameObject ability;
    public Canvas canvas;
    public RectTransform offset;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            ability = eventData.pointerDrag;
            eventData.pointerDrag.GetComponent<AbilitiesUI>().slot = this;
            Vector2 desiredPos = this.GetComponent<RectTransform>().anchoredPosition;
            desiredPos += offset.anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = desiredPos;
        }
    }
}
