using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the TMP_Text element to display score
    private int score = 0; // Player's score

    void Start()
    {
        // Initialize the score display
        UpdateScoreText();
    }

    // Method to increase the score by 1
    public void IncreaseScore()
    {
        score += 1;
        UpdateScoreText();
    }

    // Method to decrease the score by 1
    public void DecreaseScore()
    {
        score -= 1;
        UpdateScoreText();
    }

    // Update the score display on the UI
    public void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // Reset the score to 0
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}
