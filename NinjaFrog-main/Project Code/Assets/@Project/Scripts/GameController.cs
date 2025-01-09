using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int m_score;
    bool m_isGameover;
    bool m_isgameWin;
    UIManage m_ui;
    void Start()
    {
        m_ui = FindObjectOfType<UIManage>();
        m_ui.SetScoreText("Score : " + m_score);
    }

    // Update is called once per frame
    void Update()
    {

        if (m_isGameover)
        {
            m_ui.ShowGameoverPanel(true);
            return;
        }

        if (m_isgameWin)
        {
            m_ui.ShowgamewinPanel(true);
            return;
        }
    }
    public void SetScore(int value)
    {
        m_score = value;
    }

    public int GetScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        m_score = m_score + 10;
        m_ui.SetScoreText("Score : " + m_score);
    }

    public bool IsGameover()
    {
        return m_isGameover;
    }

    public void SetGameoverState(bool state)
    {
        m_isGameover = state;
    }

    public bool IsgameWin()
    {
        return m_isgameWin;
    }

    public void SetgameWinState(bool state)
    {
        m_isgameWin = state;
    }
    public void Replay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}

