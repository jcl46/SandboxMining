using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
    public Canvas CraftingMenu;
    public Canvas Inventory;
    private bool DestroyBlocks1;
    private bool DestroyBlocks2;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if (CraftingMenu.enabled == true)
        {
            DestroyBlocks1 = false;
        }
        else
        {
            DestroyBlocks1 = true;
        }
        if (Inventory.enabled == true)
        {
            DestroyBlocks2 = false;
        }
        else
        {
            DestroyBlocks2 = true;
        }

    }
        void OnMouseOver()
    {
        if(DestroyBlocks1 == DestroyBlocks2) {
            if (Input.GetMouseButton(0))
            {  // Mouse left-click: Remove a block
               // Find "MakeWorld" script
                GameObject mwo = GameObject.Find("LoadLevel");
                MakeWorld mw = mwo.GetComponent<MakeWorld>();
                // Find block index x,y at mouse
                IntVector2 bxy = mw.GetBlockIndexAtMouse();
                // Find distance to player
                if (mw.DistanceBlockToPlayer(bxy) < 4)
                {
                    // Block is close to player
                    GameObject mb = GameObject.Find("MinedBlock");
                    MinedBlockScript mbs = mb.GetComponent<MinedBlockScript>();
                    mbs.MineBlock(bxy, gameObject);
                    //                mw.RemoveBlock(gameObject);

                }
            }

           }
        }
    }
