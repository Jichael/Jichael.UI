using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickableUI : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Button button;
    
    [HideInInspector] public bool clicked;

    public void OnPointerDown(PointerEventData eventData)
    {
        clicked = true;
    }
}