using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string Egg;  // This is the name of the item.


        public List<Item> items = new List<Item>();

        public void AddItem(Item item)
        {
            items.Add(item);
            Debug.Log("Item added to inventory: " + item.items);
        }
    }
}
