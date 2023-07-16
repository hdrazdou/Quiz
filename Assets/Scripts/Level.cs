using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    #region Variables

    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;

    public CorrectAnswer Correct;
    
    [TextArea]
    public string Question;

    public Sprite QuestionSprite;

    #endregion

    #region Local data

    public enum CorrectAnswer
    {
        Answer1,
        Answer2,
        Answer3,
        Answer4,
    }

    #endregion
}