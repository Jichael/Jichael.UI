using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableUI : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector] public bool clicked;

    public void OnPointerClick(PointerEventData eventData)
    {
        clicked = true;
    }
}