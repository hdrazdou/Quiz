using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    #region Variables

    public TMP_Text MistakesAmountLabel;
    public Button RestartButton;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        MistakesAmountLabel.text = $"Mistakes made: {Statistics.WrongAnswers}";
        RestartButton.onClick.AddListener(OnRestartButtonClicked);
    }

    #endregion

    #region Private methods

    private void OnRestartButtonClicked()
    {
        SceneManager.LoadScene(SceneNames.Start);
    }

    #endregion
}