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
    public Image LevelImage;
    public TMP_Text LivesLeftLabel;
    public static int MistakesAmount;
    public TMP_Text Question;
    private int _allowedMistakesAmount;
    private string _correctAnswer;
    private Level _currentLevel;
    private int _livesLeftAmount;
    private int currentLevelIndex;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        currentLevelIndex = 0;
        _allowedMistakesAmount = 3;
        MistakesAmount = 0;
        _livesLeftAmount = _allowedMistakesAmount;
        UpdateUI();
        Answer1.onClick.AddListener(() => ApproveSelectedAnswer(Answer1));
        Answer2.onClick.AddListener(() => ApproveSelectedAnswer(Answer2));
        Answer3.onClick.AddListener(() => ApproveSelectedAnswer(Answer3));
        Answer4.onClick.AddListener(() => ApproveSelectedAnswer(Answer4));
    }

    #endregion

    #region Private methods

    private void ApproveSelectedAnswer(Button selectedButton)
    {
        string selectedAnswer = selectedButton.name.Replace("Button", "");

        if (_correctAnswer != selectedAnswer)
        {
            MistakesAmount++;
            _livesLeftAmount -= 1;
            UpdateUI();
            if (MistakesAmount == _allowedMistakesAmount)
            {
                SceneManager.LoadScene("GameOverScene");
            }

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
            return;
        }

        _currentLevel = AllLevels[currentLevelIndex];
        LivesLeftLabel.text = $"Lives left: {_livesLeftAmount}";
        _correctAnswer = _currentLevel.Correct.ToString();
        Question.text = _currentLevel.Question;
        LevelImage.sprite = _currentLevel.Sprite;
        Answer1.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer1;
        Answer2.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer2;
        Answer3.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer3;
        Answer4.GetComponentInChildren<TMP_Text>().text = _currentLevel.Answer4;
    }

    #endregion
}