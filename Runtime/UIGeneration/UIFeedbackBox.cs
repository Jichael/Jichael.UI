using CustomPackages.Silicom.Localization.Runtime;
using TMPro;
using UnityEngine;

public class UIFeedbackBox : MonoBehaviour
{
    [SerializeField] private TMP_Text feedbackText;
    [SerializeField] private UIAnimationController _type;
    

    public void SetFeedback(string feedbackKey)
    {
        feedbackText.text = LanguageManager.Instance.RequestValue(feedbackKey);
        gameObject.SetActive(true);
    }

    public void HideFeedBackBox()
    {
        gameObject.SetActive(false);
    }
}
