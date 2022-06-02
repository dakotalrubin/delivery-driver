using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This C# script allows user input to control the player game object's steer speed and move speed,
// also handling boosting and slowing, depending on  the type of object the player collides with.
// This script is attached to the player game object.
public class Driver : MonoBehaviour
{
    // This field sets a customizable rotation rate for the player game object.
    [SerializeField] float steerSpeed = 300f;

    // This field sets a customizable translation rate for the player game object.
    [SerializeField] float moveSpeed = 18f;

    // This field sets a customizable slowed speed for certain object collisions.
    [SerializeField] float slowSpeed = 14f;

    // THis field sets a customizable boosted speed for certain object collisions.
    [SerializeField] float boostSpeed = 22f;

    // This method speeds the player up when colliding with a boost pad.
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the colliding object is a boost pad...
        if (other.tag == "Boost")
        {
            // Increases the player's speed and prints an affirming message to the console
            // (unseen by player).
            moveSpeed = boostSpeed;
            Debug.Log("Whoosh!");
        }
    }

    // This method slows the player down when colliding with a solid object.
    void OnCollisionEnter2D(Collision2D other)
    {
        // If the player collides with a solid object...
        if (other.gameObject.tag == "Bump")
        {
            // Decreases the player's speed and prints a painful message to the console
            // (unseen by player).
            moveSpeed = slowSpeed;
            Debug.Log("Ouch!");
        }
    }

    // This method runs every frame, calculating movement amounts based on player input.
    void Update()
    {
        // Calculates rotation amount, multiplying user input by turn rate and a time differential
        // to account for differences in each individual player's frame rate.
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        // Calculates translation amount, multiplying user input by movement rate and a time
        // differential to account for differences in each individual player's frame rate.
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Rotates the player object by the calculated amount.
        transform.Rotate(0, 0, -steerAmount);

        // Translates the player object by the calculated amount.
        transform.Translate(0, moveAmount, 0);
    }
}