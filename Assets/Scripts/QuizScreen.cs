using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizScreen : MonoBehaviour
{
    #region Variables

    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    public Button Answer4;
    public Level Level1;
    public TMP_Text Question;
    private Level _currentLevel;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        UpdateUI();
    }

    private void Update() { }

    #endregion

    #region Private methods

    private void UpdateUI()
    {
        Question.text = 
    }

    #endregion
}