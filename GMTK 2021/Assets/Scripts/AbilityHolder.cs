using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityHolder : MonoBehaviour, IDropHandler
{
    public GameObject ability;
    public Canvas canvas;
    public RectTransform offset;
    public GameObject rabbit;
    public GameObject turtle;
    public GameObject swapZone;

    public void Start()
    {
        rabbit = GameObject.Find("Rabbit");
        turtle = GameObject.Find("Turtle");
        swapZone = GameObject.Find("SwapZone");
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (swapZone != null)
        {
            if ((rabbit.transform.position - swapZone.transform.position).magnitude <= 2 &&
                (turtle.transform.position - swapZone.transform.position).magnitude <= 2)
            {
                if (eventData.pointerDrag != null)
                {
                    ability = eventData.pointerDrag;
                    eventData.pointerDrag.GetComponent<AbilitiesUI>().slot = this;
                    Vector2 desiredPos = this.GetComponent<RectTransform>().anchoredPosition * 0.75f;
                    desiredPos += offset.anchoredPosition;
                    eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = desiredPos;
                }
            }
        }
    }
}
