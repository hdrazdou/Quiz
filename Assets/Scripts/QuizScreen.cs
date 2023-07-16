using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizScreen : MonoBehaviour
{
    #region Variables

    public List<Level> AllLevels;

    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    public Button Answer4;
    public TMP_Text Question;
    private string _correctAnswer;
    private Level _currentLevel;
    private int currentLevelIndex;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        currentLevelIndex = 0;
        UpdateUI();
        Answer1.onClick.AddListener(() => CheckSelectedAnswer(Answer1));
        Answer2.onClick.AddListener(() => CheckSelectedAnswer(Answer2));
        Answer3.onClick.AddListener(() => CheckSelectedAnswer(Answer3));
        Answer4.onClick.AddListener(() => CheckSelectedAnswer(Answer4));
    }

    #endregion

    #region Private methods

    private void CheckSelectedAnswer(Button selectedButton)
    {
        string selectedAnswer = selectedButton.name.Replace("Button", "");

        if (_correctAnswer != selectedAnswer)
        {
            return;
        }

        currentLevelIndex++;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currentLevelIndex == AllLevels.Count)
        {
            SceneManager.LoadScene("FinishScene");
        }
        _currentLevel = AllLevels[currentLevelIndex];
        _correctAnswer = _currentLevel.Correct.ToString();
        Question.text = _currentLevel.Question;
        Answer1.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer1;
        Answer2.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer2;
        Answer3.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer3;
        Answer4.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer4;
    }

    #endregion
}