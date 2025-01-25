using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float lifetime = 0.5f; // Time before the bubble disappears
    public float pushForce = 5f; // Force applied to the player on collision
    private static List<GameObject> activeBubbles = new List<GameObject>(); // Tracks active bubbles
    private static int maxBubbles = 8; // Maximum number of bubbles allowed

    private void Start()
    {
        // Add the bubble to the active list
        activeBubbles.Add(gameObject);

        // Check if the number of bubbles exceeds the limit
        if (activeBubbles.Count > maxBubbles)
        {
            // Destroy the oldest bubble
            Destroy(activeBubbles[0]);
            activeBubbles.RemoveAt(0);
        }

        // Schedule this bubble for destruction after its lifetime
        Destroy(gameObject, lifetime);
    }

    private void OnDestroy()
    {
        // Remove the bubble from the active list if it gets destroyed
        activeBubbles.Remove(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the bubble collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the player's Rigidbody2D
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Calculate the push direction (from bubble to player)
                Vector2 pushDirection = (collision.transform.position - transform.position).normalized;

                // Apply force to the player in the push direction
                playerRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

                Debug.Log($"Bubble pushed the player with force {pushForce} in direction {pushDirection}");
            }

            // Destroy the bubble after interacting with the player
            Destroy(gameObject);
        }
    }
}


