using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMesh Pro

public class EggTimer : MonoBehaviour
{
    public float timer = 10f; // Time before egg is destroyed
    public Transform coral; // The coral position
    public float distanceThreshold = 1f; // Distance to coral to be considered in time
    public TMP_Text timerText; // Reference to the TMP_Text element to display messages
    public GameObject eggPrefab; // Reference to the egg prefab to instantiate new eggs

    public Vector2 spawnAreaMin; // Minimum bounds of the spawn area (X and Y coordinates)
    public Vector2 spawnAreaMax; // Maximum bounds of the spawn area (X and Y coordinates)

    private scoreManager scoreManager; // Reference to the ScoreManager script
    private bool isEggInCoral = false; // Flag to check if the egg reached the coral

    void Start()
    {
        // Initialize the timer text at the start
        if (timerText != null)
        {
            timerText.text = "Time Left: " + timer.ToString("F1");
        }

        // Initialize the ScoreManager
        scoreManager = FindObjectOfType<scoreManager>();

        // Initialize the score display
        if (scoreManager != null)
        {
            scoreManager.UpdateScoreText();
        }
    }

    void Update()
    {
        // If the egg has not reached the coral yet and the timer hasn't run out
        if (!isEggInCoral)
        {
            timer -= Time.deltaTime;

            // Ensure we are using 2D positions for the distance check
            Vector2 eggPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 coralPosition = new Vector2(coral.position.x, coral.position.y);

            // Check if the egg is within distance of the coral
            if (Vector2.Distance(eggPosition, coralPosition) <= distanceThreshold)
            {
                isEggInCoral = true; // The egg has reached the coral
                DisplayMessage("Egg reached coral in time!");
                StopTimer(); // Stop the timer
                scoreManager.IncreaseScore(); // Increase score by 1
                GenerateNewEgg(); // Generate a new egg
            }

            // Update the timer display only if the egg has not reached the coral yet
            if (timer > 0f && !isEggInCoral)
            {
                if (timerText != null)
                {
                    timerText.text = "Time Left: " + timer.ToString("F1");
                }
            }

            // If the timer runs out, destroy the egg
            if (timer <= 0f && !isEggInCoral)
            {
                DestroyEgg();
            }
        }
    }

    void DestroyEgg()
    {
        if (timerText != null)
        {
            timerText.text = "Egg destroyed due to timer running out!";
        }
        scoreManager.DecreaseScore(); // Decrease score by 1
        Destroy(gameObject); // Destroy the egg
        GenerateNewEgg(); // Generate a new egg
    }

    void StopTimer()
    {
        // Stop the timer from decreasing once the egg reaches the coral
        timer = 0; // Immediately stop the timer
        if (timerText != null)
        {
            timerText.text = "Egg reached coral in time!";
        }
    }

    void DisplayMessage(string message)
    {
        if (timerText != null)
        {
            timerText.text = message;
        }
    }

    void GenerateNewEgg()
    {
        // Randomize the spawn position within the defined area
        float randomX = Random.Range(spawnAreaMin.x, spawnAreaMax.x);
        float randomY = Random.Range(spawnAreaMin.y, spawnAreaMax.y);
        Vector3 randomSpawnPosition = new Vector3(randomX, randomY, 0f); // Adjust Z if necessary

        // Instantiate a new egg at the random spawn position
        if (eggPrefab != null)
        {
            Instantiate(eggPrefab, randomSpawnPosition, Quaternion.identity);
        }
    }
}
