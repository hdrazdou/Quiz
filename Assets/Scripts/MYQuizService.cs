using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MYQuizService : MonoBehaviour
{
    #region Variables
    
    public List<QuestionConfig> AllLevels;
    
    public QuestionsContainerConfig ContainerConfig;
    public GameScreen GameScreen;
    
    private int _currentQuestionIndex;
    
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
    private QuestionConfig _currentQuestion;
    private bool _isHintUsed;
    private int _livesLeftAmount;
    

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _currentQuestionIndex = 0;
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
            MistakesAmount++;
            _livesLeftAmount -= 1;
            UpdateUI();

            if (MistakesAmount == _allowedMistakesAmount)
            {
                SceneManager.LoadScene("GameOverScene");
            }

            return;
        }

        _currentQuestionIndex++;
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
        if (_currentQuestionIndex == AllLevels.Count)
        {
            SceneManager.LoadScene(SceneNames.Finish);
            return;
        }

        _currentQuestion = AllLevels[_currentQuestionIndex];
        LivesLeftLabel.text = $"Lives left: {_livesLeftAmount}";
        _correctAnswer = _currentQuestion.Correct.ToString();
        Question.text = _currentQuestion.Question;
        LevelImage.sprite = _currentQuestion.Icon;
        Answer1.GetComponentInChildren<TMP_Text>().text = _currentQuestion.Answer1;
        Answer2.GetComponentInChildren<TMP_Text>().text = _currentQuestion.Answer2;
        Answer3.GetComponentInChildren<TMP_Text>().text = _currentQuestion.Answer3;
        Answer4.GetComponentInChildren<TMP_Text>().text = _currentQuestion.Answer4;
    }

    #endregion
}