using UnityEngine;

[CreateAssetMenu(fileName = "Notification_", menuName = "Notification")]
public class NotificationSO : ScriptableObject
{
    public string textKey = "Notification_";
    public Color color;
    public AudioClip audioClip;
    public float timeToLive;
}