using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [TextArea]
    public string Question;

    public Sprite QuestionSprite;
    
    public string Answer1;
    public string Answer2;
    public string Answer3;
    public string Answer4;

    public List<Level> AllLevels;
}