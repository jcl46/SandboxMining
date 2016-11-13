using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemManagerScript : MonoBehaviour {

    class Item
    {
        public string itemID = "";
        public string itemName = "";
        public int maxStackSize = 0;
        public Sprite sprite = null;
    }

    List<Item> itemList;

    class Block
    {
        public string blockID = "";
        public string blockName = "";
        public Sprite sprite = null;
    }

    List<Block> blockList;

    // Use this for initialization
    void Start() {
        // Create the list of all item types
        itemList = new List<Item>();
        Item item;
        item = new Item();
        item.itemID = "dirt"; item.itemName = "Dirt"; item.maxStackSize = 4; itemList.Add(item);
        item.sprite = Resources.Load("dirt", typeof(Sprite)) as Sprite;
        item = new Item();
        item.itemID = "stone"; item.itemName = "Stone"; item.maxStackSize = 99; itemList.Add(item);
        item.sprite = Resources.Load("stone", typeof(Sprite)) as Sprite;
        // Create the list of all block types
        blockList = new List<Block>();
        Block block;
        block = new Block();
        block.blockID = "dirt"; block.blockName = "Dirt"; blockList.Add(block);
        block.sprite = Resources.Load("dirt", typeof(Sprite)) as Sprite;
        block = new Block();
        block.blockID = "grass"; block.blockName = "Grass"; blockList.Add(block);
        block.sprite = Resources.Load("grassTop", typeof(Sprite)) as Sprite;
        block = new Block();
        block.blockID = "stone"; block.blockName = "Stone"; blockList.Add(block);
        block.sprite = Resources.Load("stone", typeof(Sprite)) as Sprite;
    }


    // Update is called once per frame
    void Update() {

    }

    Block GetBlock(string blockID)
    {
        for (int i = 0; i < blockList.Count; i++)
        {
            if (blockList[i].blockID == blockID)
            {
                return blockList[i];
            }
        }
        return null;  // block not found
    }

    Item GetItem(string itemID)
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            if (itemList[i].itemID == itemID)
            {
                return itemList[i];
            }
        }
        return null;  // block not found
    }

    // Get the sprite (texture) for a block type
    public Sprite GetBlockSprite(string blockID)
    {
        Block block = GetBlock(blockID);
        if (block != null)
            return block.sprite;
        else
            return null;
    }

    // Get the sprite (texture) for an item type
    public Sprite GetItemSprite(string itemID)
    {
        Item item = GetItem(itemID);
        if (item != null)
            return item.sprite;
        else
            return null;
    }

    // Get the max stack size for an item type
    public int GetItemMaxStackSize(string itemID)
    {
        Item item = GetItem(itemID);
        if (item != null)
            return item.maxStackSize;
        else
            return -1;
    }

    // Spawn item with itemID at position xy
    public void SpawnItem(string itemID, Vector2 xy) {
        GameObject dirt = GameObject.Find("dirt");   // Find a gameobject to use as template
        // TODO: sprite texture should be changed to that of itemID
        GameObject go = Instantiate(dirt);
        go.transform.position = new Vector3(xy.x,xy.y,-8);
        // Apply random force
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>() as Rigidbody2D;
        System.Random random = new System.Random();
        int x = random.Next(-100, 100);
        rb.AddForce(new Vector2(x, 100));
    }



}
