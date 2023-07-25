using UnityEngine;

[CreateAssetMenu(fileName = nameof(QuestionsContainerConfig), menuName = "Quiz/Questions Container")]

public class QuestionsContainerConfig : ScriptableObject
{
    public QuestionConfig[] Questions;
}