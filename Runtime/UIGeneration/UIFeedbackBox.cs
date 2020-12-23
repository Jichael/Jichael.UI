using System;
using CustomPackages.Silicom.Localization.Runtime;
using TMPro;
using UnityEngine;

public class UIFeedbackBox : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text feedbackText;

    public void SetFeedback(Feedback feedback)
    {
        titleText.text = LanguageManager.Instance.RequestValue(feedback.titleKey);
        feedbackText.text = LanguageManager.Instance.RequestValue(feedback.feedbackKey);
        gameObject.SetActive(true);
    }

    public void HideFeedBackBox()
    {
        gameObject.SetActive(false);
    }

    [Serializable]
    public class Feedback
    {
        public string titleKey;
        public string feedbackKey;
    }
}
