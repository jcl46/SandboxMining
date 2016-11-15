using UnityEngine;
using System.Collections;

/// <summary>
/// The inventory manager handles inventory of the player
/// </summary>

public class InventoryManagerScript : MonoBehaviour {

    class Inventory_slot
    {
        public string itemID = "";  // Item type in the inventory slot
        public int stacksize = 128;   // Number of items stacked in the inventory slot
    }

    public const int INVENTORY_SPACES = 30;   // Number of spaces in the inventory
    Inventory_slot[] inventory = new Inventory_slot[INVENTORY_SPACES];

    // Use this for initialization
    void Start () {
        for (int i = 0; i < INVENTORY_SPACES; i++)
        {
            inventory[i] = new Inventory_slot();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void UpdateInventoryGUI()
    {
        GameObject im = GameObject.Find("InventoryMenu");
        InventoryMenuScript ims = im.GetComponent<InventoryMenuScript>();
        ims.UpdateGUI();
    }

    public string GetInventoryItemID(int iSlot)
    {
        return inventory[iSlot].itemID;
    }

    public int GetInventoryStackSize(int iSlot)
    {
        return inventory[iSlot].stacksize;
    }

    public bool AddItemToInventory(string itemID)
    {  // Add item to inventory. Return true if succesful
        GameObject im = GameObject.Find("ItemManager");
        ItemManagerScript ims = im.GetComponent<ItemManagerScript>();
        for (int i = 0; i < INVENTORY_SPACES; i++)
        {
            if (inventory[i].itemID == itemID) 
            {  // Slot found that contains the same item (itemID)
               if (inventory[i].stacksize < ims.GetItemMaxStackSize(itemID)) {
                    // Stack not full. Add the item
                    inventory[i].stacksize++;
                    UpdateInventoryGUI();
                    return true;
                }
            }
            if (inventory[i].itemID == "") {
                // Free inventory slot found
                inventory[i].itemID = itemID;
                inventory[i].stacksize = 1;
                UpdateInventoryGUI();
                return true;
            }
        }
        return false;  // No free inventory slot found
    }
}
