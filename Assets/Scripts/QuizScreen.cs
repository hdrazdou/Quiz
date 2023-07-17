using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuizScreen : MonoBehaviour
{
    #region Variables

    public List<LevelConfig> AllLevels;
    public Button Answer1;
    public Button Answer2;
    public Button Answer3;
    public Button Answer4;
    public Button HintButton;
    public Image LevelImage;
    public TMP_Text LivesLeftLabel;
    public static int MistakesAmount;
    public TMP_Text Question;
    private int _allowedMistakesAmount;
    private string _correctAnswer;
    private LevelConfig _currentLevel;
    private bool _isHintUsed;
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
        HintButton.onClick.AddListener(OnHintButtonClicked);
    }

    #endregion

    #region Private methods

    private void _restoreRemovedButtons()
    {
        if (_isHintUsed)
        {
            Answer1.gameObject.SetActive(true);
            Answer2.gameObject.SetActive(true);
            Answer3.gameObject.SetActive(true);
            Answer4.gameObject.SetActive(true);
            HintButton.gameObject.SetActive(true);
        }
    }

    private void ApproveSelectedAnswer(Button selectedButton)
    {
        string selectedAnswer = selectedButton.name.Replace("Button", "");

        if (_correctAnswer != selectedAnswer)
        {
            // WrongButtonClicked(selectedButton);
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
        _restoreRemovedButtons();
        UpdateUI();
    }

    private void OnHintButtonClicked()
    {
        _isHintUsed = true;

        List<Button> ButtonsToRemove = new() { Answer1, Answer2, Answer3, Answer4 };

        int indexToRemove = int.Parse(_correctAnswer.Replace("Answer", "")) - 1;
        ButtonsToRemove.RemoveAt(indexToRemove);

        indexToRemove = Random.Range(0, 3);
        ButtonsToRemove.RemoveAt(indexToRemove);
        
        ButtonsToRemove[0].gameObject.SetActive(false);
        ButtonsToRemove[1].gameObject.SetActive(false);

        HintButton.gameObject.SetActive(false);
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

    // private void WrongButtonClicked(Button selectedButton)
    // {
    //     ColorBlock colors = selectedButton.colors;
    //     colors.normalColor = Color.red;
    //     selectedButton.colors = colors;
    // }
}