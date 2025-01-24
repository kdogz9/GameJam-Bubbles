using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEggs : MonoBehaviour
{
    private Inventory inventory;  // Class-level variable
    public GameObject itemButton;

    private void Start()
    {
        // Assign the class-level variable directly
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Corrected tag case here
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (!inventory.isFull[i])  // Simplified check
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);  // Destroys the item after it's picked up
                    break;
                }
            }
        }
    }
}
