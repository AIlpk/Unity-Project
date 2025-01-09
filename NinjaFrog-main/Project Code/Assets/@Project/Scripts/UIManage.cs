using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManage : MonoBehaviour
{
    public Text scoreText;
    public GameObject gameoverPanel;
    public GameObject gamewinPanel;

    public void SetScoreText(string txt)
    {
        if (scoreText)
            scoreText.text = txt;
    }
    public void ShowGameoverPanel(bool isShow)
    {
        if (gameoverPanel)
            gameoverPanel.SetActive(isShow);
        

    }
    public void ShowgamewinPanel(bool isShow)
    {
        if (gamewinPanel)
            gamewinPanel.SetActive(isShow);
        
    }

   

}
