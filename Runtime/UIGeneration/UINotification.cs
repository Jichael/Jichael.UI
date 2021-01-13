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

    public void SetNotification(NotificationSO notificationSo)
    {
        image.color = notificationSo.color;
        notificationText.text = LanguageManager.Instance.RequestValue(notificationSo.textKey);
        animationController.PlayAnimation(0);
        AudioManager.Instance.PlayUIClip(notificationSo.audioClip);
        StartCoroutine(RemoveCo(notificationSo.timeToLive));
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