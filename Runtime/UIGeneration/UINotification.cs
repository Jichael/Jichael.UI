using System.Collections;
using CustomPackages.Silicom.Core.Runtime;
using CustomPackages.Silicom.Localization.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UINotification : MonoBehaviour
{
    [SerializeField] private UIAnimationController animationController;
    [SerializeField] private TMP_Text notificationText;
    [SerializeField] private Image image;

    private NotificationSO _notification;

    public void SetNotification(NotificationSO notificationSo)
    {
        _notification = notificationSo;
        image.color = _notification.color;
        notificationText.text = LanguageManager.Instance.RequestValue(_notification.textKey);
    }

    public void OverrideText(string text)
    {
        notificationText.text = text;
    }

    public void PlayAnimation()
    {
        animationController.PlayAnimation(0);
        AudioManager.Instance.PlayUIClip(_notification.audioClip);
        StartCoroutine(RemoveCo(_notification.timeToLive));
    }
    
    private IEnumerator RemoveCo(float timeToLive)
    {
        yield return new WaitForSeconds(timeToLive);
        animationController.PlayAnimation(1);
        do { yield return Yielders.EndOfFrame; } 
        while (animationController.AnimationPlaying);
        Destroy(gameObject);
    }


}