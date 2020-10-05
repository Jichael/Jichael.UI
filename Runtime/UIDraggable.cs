using UnityEngine;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour, IDragHandler
{

    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private RectTransform toDrag;

    public void OnDrag(PointerEventData eventData)
    {
        toDrag.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }

}