using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    #region Variables

    public TMP_Text NameLabel;
    public Button StartButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClicked);
    }

    #endregion

    #region Private methods

    private void OnStartButtonClicked()
    {
        SceneManager.LoadScene("QuizScene");
    }

    #endregion
}