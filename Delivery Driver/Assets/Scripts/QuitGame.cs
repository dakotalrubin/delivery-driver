using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A simple C# script that checks every frame whether the player is pressing the "escape" key.
// This script is attached to an empty game object.
public class QuitGame : MonoBehaviour
{
    // This method runs every frame.
    void Update()
    {
        // Checks each update loop for an "escape" key press.
        if (Input.GetKeyDown("escape"))
        {
            // The game's exit condition.
            Application.Quit();
        }
    }
}