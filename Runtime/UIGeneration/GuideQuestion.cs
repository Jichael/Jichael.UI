using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GuideQuestion", menuName = "Guide/Question", order = 1)]
public class GuideQuestion : ScriptableObject
{
    public string titleKey;
    public string questionKey;
    public Answer[] answers;

    [Serializable]
    public class Answer
    {
        public string answerKey;
        public bool correctAnswer;
    }
}