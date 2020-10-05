using UnityEngine;
using UnityEngine.EventSystems;

public class UIForegroundOnClick : MonoBehaviour, IPointerDownHandler
{
    [SerializeField, HideInInspector] private RectTransform rectTransform;

    private void OnValidate()
    {
        rectTransform = transform as RectTransform;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rectTransform.SetAsLastSibling();
    }
}