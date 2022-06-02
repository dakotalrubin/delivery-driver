using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This C# script checks the player game object's position to update the camera's position.
// This script is attached to the main camera game object.
public class FollowCamera : MonoBehaviour
{
    // Creates a field in the inspector where the player game object can be designated.
    [SerializeField] GameObject ObjectToFollow;

    // The camera's position should be calculated after player movement at the end of every frame.
    void LateUpdate()
    {
        // The camera's position should match the player's position, plus an out-of-screen offset.
        transform.position = ObjectToFollow.transform.position + new Vector3 (0, 0, -10);
    }
}