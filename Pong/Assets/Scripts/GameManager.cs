using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Ball ball;
    public Paddle playerPaddle;
    public Paddle player2;
    public Text playerScoreText;
    public Text player2ScoreText;

    private int playerScore;
    private int player2Score;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetPlayer2Score(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        player2.ResetPosition();
        ball.ResetPosition();

        CancelInvoke();
        Invoke(nameof(StartRound), 1f);
    }

    private void StartRound()
    {
        ball.AddStartingForce();
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
        NewRound();
    }

    public void OnPlayer2Scored()
    {
        SetPlayer2Score(player2Score + 1);
        NewRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetPlayer2Score(int score)
    {
        player2Score = score;
        player2ScoreText.text = score.ToString();
    }
}
