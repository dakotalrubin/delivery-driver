using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This C# script handles event triggering between the player and customer game object colliders.
// This script is attached to the player game object.
public class Delivery : MonoBehaviour
{
    // The player starts the game without a package for delivery.
    bool hasPackage = false;

    // The player game object has default coloring to indicate no current package.
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    // The player game object has customizable color to indicate possession of a package.
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);

    // Adds brief visual delay before package disappears.
    [SerializeField] float destroyDelay = 0.2f;

    // Creates variable to contain player's SpriteRenderer component.
    SpriteRenderer spriteRenderer;

    // This method assigns the player game object's SpriteRenderer component at initialization.
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // This method checks the tag of the game object that the player game object collides with.
    // Different events are triggered based on the object's tag.
    void OnTriggerEnter2D(Collider2D other)
    {
        // If the player collides with a package and doesn't currently have one...
        if (other.tag == "Package" && !hasPackage)
        {
            // The player's Sprite Renderer component color updates to reflect received package.
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;

            // A brief message indicating the update gets printed to the console (unseen by player).
            Debug.Log("Package picked up!");

            // The package game object is then destroyed after the specified delay time.
            Destroy(other.gameObject, destroyDelay);
        }

        // If the player collides with a customer and has a package...
        if (other.tag == "Customer" && hasPackage == true)
        {
            // The player's Sprite Renderer component color updates to reflect dropped off package.
            hasPackage = false;
            spriteRenderer.color = noPackageColor;

            // A brief message indicating the update gets printed to the console (unseen by player).
            Debug.Log("Package delivered!");
        }
    }
}