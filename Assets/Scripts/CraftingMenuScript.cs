using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class CraftingMenuScript : MonoBehaviour {

    public Canvas CraftingMenu;
    public Canvas InventoryMenu;
    public Canvas Hotbar;
    private bool bCraftingMenuVisible = false;
    private bool bInventoryMenuVisible = false;

    // Use this for initialization
    void Start () {
        CraftingMenu = CraftingMenu.GetComponent<Canvas>();
        Hotbar = Hotbar.GetComponent<Canvas>();
        CraftingMenu.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
        {
            if (bCraftingMenuVisible)
                ResumePress();
            else
                CPress();
        }
    }

    public void CPress()

    {
        CraftingMenu.enabled = true;
        bCraftingMenuVisible = true;
        InventoryMenu.enabled = false;
        bInventoryMenuVisible = false;
        Hotbar.enabled = true;

    }

    public void ResumePress()

    {
        CraftingMenu.enabled = false;
        bCraftingMenuVisible = false;
        Hotbar.enabled = true;
    }
}
