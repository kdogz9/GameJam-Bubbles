using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    void Update()
    {
        // Listen for the Esc key press to exit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGameBuild(); // Call method to quit the game
        }
    }

    // Method to handle exiting the game
    void ExitGameBuild()
    {
        // If we are running a game build (not in the Unity editor), quit the application
        Application.Quit();

        // Optionally, you can also log this in the console for debugging purposes
        Debug.Log("Game is quitting...");
    }
}
