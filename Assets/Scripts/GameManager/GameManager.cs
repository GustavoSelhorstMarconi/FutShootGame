using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Configurations")]
    [SerializeField]
    private UnityEvent OnGoal;
    [SerializeField]
    private float timeToRestartGoal;

    [Header("References")]
    [SerializeField]
    private GameObject playerOne;
    [SerializeField]
    private GameObject playerTwo;
    [SerializeField]
    private GameObject playerThree;
    [SerializeField]
    private GameObject playerFour;
    [SerializeField]
    private GameObject levelTwoPlayers;
    [SerializeField]
    private GameObject levelThreePlayers;
    [SerializeField]
    private GameObject levelFourPlayers;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private ScriptableMode modeValue;
    [SerializeField]
    private Button backToMenuButton;

    private int scoreLeftPlayer;
    private int scoreRightPlayer;
    private int scoreUpPlayer;
    private int scoreDownPlayer;

    private void Start()
    {
        playerThree.SetActive(modeValue.modeSelected >= 3);
        playerFour.SetActive(modeValue.modeSelected == 4);

        levelTwoPlayers.SetActive(modeValue.modeSelected == 2);
        levelThreePlayers.SetActive(modeValue.modeSelected == 3);
        levelFourPlayers.SetActive(modeValue.modeSelected == 4);

        backToMenuButton.onClick.AddListener(BackToMenu);
        SetTextScore();
    }

    private void SetTextScore()
    {
        if (modeValue.modeSelected == 2)
        {
            scoreText.SetText(scoreLeftPlayer + " - " + scoreRightPlayer);
        }
        else if (modeValue.modeSelected == 3)
        {
            scoreText.SetText(scoreLeftPlayer + " - " + scoreRightPlayer + " - " + scoreUpPlayer);
        }
        else if (modeValue.modeSelected == 4)
        {
            scoreText.SetText(scoreLeftPlayer + " - " + scoreRightPlayer + " - " + scoreUpPlayer + " - " + scoreDownPlayer);
        }
    }

    private void CallOnGoal()
    {
        OnGoal?.Invoke();
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ScoreRightGoal()
    {
        if (modeValue.modeSelected == 2)
        {
            scoreLeftPlayer++;
        }
        else
        {
            scoreRightPlayer--;
        }
        SetTextScore();
        Invoke(nameof(CallOnGoal), timeToRestartGoal);
    }

    public void ScoreLeftGoal()
    {
        if (modeValue.modeSelected == 2)
        {
            scoreRightPlayer++;
        }
        else
        {
            scoreLeftPlayer--;
        }
        SetTextScore();
        Invoke(nameof(CallOnGoal), timeToRestartGoal);
    }

    public void ScoreUpGoal()
    {
        scoreUpPlayer--;
        SetTextScore();
        Invoke(nameof(CallOnGoal), timeToRestartGoal);
    }

    public void ScoreDownGoal()
    {
        scoreDownPlayer--;
        SetTextScore();
        Invoke(nameof(CallOnGoal), timeToRestartGoal);
    }
}