using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpEggs : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        // player starts with inventory
    }



     void OnTriggerEnter2D(Collider2D other)
        // if player collides with the object we want them to pick it up 
    { 
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++) // checking if inventory is full or empty , if its not then we can add it to inventory 
            {
                if(inventory.isFull[i] == false)
                    // item is added to inventory
                {
                    inventory.isFull[i] = true; // inventory is now full and so the loop stops 
                    Instantiate(itemButton, inventory.slots[i].transform);
                    Destroy(gameObject);
                    break; 
                }
            }
        }
    }
}
