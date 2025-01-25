using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public GameObject pickedUpItem; // Reference to the currently picked-up item
    public float dropDistance = 1f; // Distance from the player where the item will drop
    private Vector2 lastMovementDirection = Vector2.down; // Default facing direction

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the tag "Item" and no item is currently held
        if (pickedUpItem == null && collision.gameObject.CompareTag("Item"))
        {
            // Pick up the item
            pickedUpItem = collision.gameObject;

            // Disable the item's collider to prevent further collisions
            collision.gameObject.GetComponent<Collider2D>().enabled = false;

            // Disable the item's renderer to make it "disappear" visually
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;

            // Optional: Disable the Rigidbody2D to stop movement (if any)
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null) rb.isKinematic = true;
        }
    }

    void Update()
    {
        // Capture player's movement direction
        Vector2 movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movementInput != Vector2.zero)
        {
            lastMovementDirection = movementInput.normalized; // Store the last movement direction
        }

        // Drop the item when the E key is pressed
        if (Input.GetKeyDown(KeyCode.E) && pickedUpItem != null)
        {
            DropItem();
        }
    }

    void DropItem()
    {
        // Re-enable the item's collider
        pickedUpItem.GetComponent<Collider2D>().enabled = true;

        // Re-enable the item's renderer to make it visible again
        pickedUpItem.GetComponent<SpriteRenderer>().enabled = true;

        // Calculate the drop position based on the last movement direction
        Vector3 dropPosition = (Vector2)transform.position + lastMovementDirection * dropDistance;

        // Place the item at the drop position
        pickedUpItem.transform.position = dropPosition;

        // Optional: Re-enable the Rigidbody2D to allow the item to interact with physics again
        Rigidbody2D rb = pickedUpItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.velocity = Vector2.zero; // Reset velocity to avoid unintended movement
        }

        // Clear the reference to the dropped item
        pickedUpItem = null;
    }
}
