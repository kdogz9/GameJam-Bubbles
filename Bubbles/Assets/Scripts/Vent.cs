using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vent : MonoBehaviour
{
    public GameObject bubblePrefab; // Prefab for the bubble
    public float spawnInterval = 1f; // Time between bubble spawns
    public float bubbleForce = 5f; // Force applied by the bubble to the player
    public Vector2 bubbleDirection = Vector2.up; // Default direction for the bubbles
    public float randomDirectionVariance = 0.2f; // Variance in bubble direction

    private void Start()
    {
        // Start spawning bubbles at regular intervals
        InvokeRepeating(nameof(SpawnBubble), 0f, spawnInterval);
    }

    private void SpawnBubble()
    {
        // Create a new bubble at the vent's position
        GameObject bubble = Instantiate(bubblePrefab, transform.position, Quaternion.identity);

        // Add a slight random variance to the bubble's direction
        Vector2 randomVariance = new Vector2(
            Random.Range(-randomDirectionVariance, randomDirectionVariance),
            Random.Range(-randomDirectionVariance, randomDirectionVariance)
        );
        Vector2 finalDirection = (bubbleDirection + randomVariance).normalized;

        // Apply force to the bubble's Rigidbody2D to push it in the direction
        Rigidbody2D bubbleRb = bubble.GetComponent<Rigidbody2D>();
        if (bubbleRb != null)
        {
            bubbleRb.AddForce(finalDirection * bubbleForce, ForceMode2D.Impulse);
        }
    }
}





