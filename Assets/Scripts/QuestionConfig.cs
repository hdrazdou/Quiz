using UnityEngine;

[CreateAssetMenu(fileName = nameof(QuestionConfig), menuName = "Configs/Level Config")]
public class QuestionConfig : ScriptableObject
{
    #region Variables

    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;

    public CorrectAnswer Correct;

    public Sprite Icon;

    [TextArea]
    public string Question;

    #endregion

    #region Properties

    public int CorrectIndex => (int)Correct;

    #endregion
}