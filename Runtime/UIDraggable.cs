using UnityEngine;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour, IDragHandler, IEndDragHandler
{

    [SerializeField] private Canvas parentCanvas;
    [SerializeField] private RectTransform toDrag;
    
    private const int MIN_BORDER_X = 100;
    private const int MIN_BORDER_Y = 50;

    public void OnDrag(PointerEventData eventData)
    {
        toDrag.anchoredPosition += eventData.delta / parentCanvas.scaleFactor;
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 endPos = toDrag.anchoredPosition;

        Rect rect = ((RectTransform) parentCanvas.transform).rect;

        float tmpPos = -toDrag.rect.width + MIN_BORDER_X;

        if (endPos.x < tmpPos)
        {
            endPos.x = tmpPos;
        }
        else
        {
            tmpPos = rect.width - MIN_BORDER_X;
            if (endPos.x > tmpPos)
            {
                endPos.x = tmpPos;
            }
        }

        tmpPos = -toDrag.rect.height + MIN_BORDER_Y;
        
        if (endPos.y < tmpPos)
        {
            endPos.y = tmpPos;
        }
        else
        {
            tmpPos = rect.height - toDrag.rect.height - MIN_BORDER_Y;
            if (endPos.y > tmpPos)
            {
                endPos.y = tmpPos;
            }
        }

        toDrag.anchoredPosition = endPos;
    }
}