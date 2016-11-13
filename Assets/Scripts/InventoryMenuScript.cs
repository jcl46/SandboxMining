using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class InventoryMenuScript : MonoBehaviour
{

    public Canvas InventoryMenu;
    public Canvas Hotbar;
    GameObject[] ItemInInventoryList = null;

    private bool bInventoryMenuVisible = false;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (bInventoryMenuVisible)
                ResumePress();
            else
                IPress();
        }
    }


    // Use this for initialization
    void Start()
    {
        InventoryMenu = InventoryMenu.GetComponent<Canvas>();

        InventoryMenu.enabled = false;
        Hotbar.enabled = true;
        // Create ItemInInventory objects for each inventory slot
        ItemInInventoryList = new GameObject[InventoryManagerScript.INVENTORY_SPACES];
        GameObject iii0 = GameObject.Find("ItemInInventory0");
        ItemInInventoryList[0] = iii0;
        for (int i = 1; i < InventoryManagerScript.INVENTORY_SPACES; i++)
        {
            GameObject isi = GameObject.Find("InventorySlot"+i);
            if (isi == null)
                ItemInInventoryList[i] = null;
            else
            {
                InventorySlotScript iss = isi.GetComponent<InventorySlotScript>();
                if (iss != null)
                    iss.InventorySlotIndex = i;
                GameObject itemcopy = Instantiate(iii0) as GameObject;
                itemcopy.transform.SetParent(isi.transform);
                itemcopy.transform.localPosition = iii0.transform.localPosition;
                itemcopy.transform.localScale = iii0.transform.localScale;
                itemcopy.name = "ItemInInventory" + i;
                ItemInInventoryList[i] = itemcopy;
            }
        }
    }

    public void IPress()

    {
        InventoryMenu.enabled = true;
        Hotbar.enabled = false;
        bInventoryMenuVisible = true;
        UpdateGUI();
    }

    public void ResumePress()

    {
        InventoryMenu.enabled = false;
        Hotbar.enabled = true;
        bInventoryMenuVisible = false;
    }

    public void UpdateGUI()
    {  // Update items in the inventory slots
        GameObject inm = GameObject.Find("InventoryManager");
        InventoryManagerScript ims = inm.GetComponent<InventoryManagerScript>();
        GameObject im = GameObject.Find("ItemManager");
        ItemManagerScript itemmgrs = im.GetComponent<ItemManagerScript>();
        for (int i = 0; i < InventoryManagerScript.INVENTORY_SPACES; i++)
        {
            GameObject iii = ItemInInventoryList[i];
            if (iii != null)
            {
                string itemID = ims.GetInventoryItemID(i);
                if (itemID == "")
                    iii.SetActive(false);  // Inventory slot empty
                else
                {  // Inventory slot not empty
                    Sprite sprite = itemmgrs.GetItemSprite(itemID);
                    iii.GetComponent<Image>().sprite = sprite;
                    // Set stack text
                    Text[] textcomp = iii.GetComponentsInChildren<Text>();
                    int ss = ims.GetInventoryStackSize(i);
                    if (ss == 1)
                        textcomp[0].text = "";
                    else              
                        textcomp[0].text = ss.ToString();
                    // Set active
                    iii.SetActive(true);
                }
            }

        }
    }
}
