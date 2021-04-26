using UnityEngine;

public class UINotificationArea : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private UINotification notificationTemplate;

    public void SendNotification(NotificationSO notification)
    {
        UINotification notif = Instantiate(notificationTemplate, parent);
        notif.SetNotification(notification);
        notif.PlayAnimation();
    }
    
    public void SendNotification(NotificationSO notification, string textOverride)
    {
        UINotification notif = Instantiate(notificationTemplate, parent);
        notif.SetNotification(notification);
        notif.OverrideText(textOverride);
        notif.PlayAnimation();
    }

}