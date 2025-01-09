using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ball : MonoBehaviour
{   
    public float minY = -5.5f;
    public float maxVelocity = 15f;
    Rigidbody2D rb; 

    int score = 0;
    int lives = 5;
    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;
    public GameObject gameOverPanel;
    public GameObject youWinPanel;
    public int BrickCount; // Số lượng viên gạch

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        BrickCount = FindObjectOfType<Level>().transform.childCount;
    }

    void Update()
    {
        if(transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero;
                rb.velocity = Vector3.zero;
                lives--;
                livesImage[lives].SetActive(false);
            }
        }

        if (lives <= 0) // Kiểm tra số mạng, nếu không còn mạng nào thì kết thúc trò chơi
        {
            GameOver();
        }

        if(rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score += 10;
            scoreTxt.text = score.ToString("00000");
            BrickCount--;
            if (BrickCount <= 0)
            {
                youWinPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            // Destroy the brick that was hit
            Destroy(collision.gameObject);

            // Find all remaining bricks and destroy them
            GameObject[] allBricks = GameObject.FindGameObjectsWithTag("Brick");
            foreach (GameObject brick in allBricks)
            {
                Destroy(brick);
            }

            // Update score
            score += 10 * (BrickCount + 1); // Add 10 points for each brick destroyed
            scoreTxt.text = score.ToString("00000");

            // Since all bricks are destroyed, set BrickCount to 0
            BrickCount = 0;

            // Display the win panel
            youWinPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }*/



    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
