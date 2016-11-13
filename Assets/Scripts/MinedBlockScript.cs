using UnityEngine;
using System.Collections;

public class MinedBlockScript : MonoBehaviour {

    private IntVector2 blockBeingMined_xy = new IntVector2(-1, -1);  // Block that is currently being mined
    private int blockBeingMined_health = -1;                          // Health of the block currently being mined
    private bool bBlockMinedThisFrame = false;
    const int BLOCK_MAX_HEALTH = 30;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!bBlockMinedThisFrame && blockBeingMined_health>=0)
        {  // A block is being mined, but not this frame
            blockBeingMined_health += 1;
            // Stop mining sound
            GameObject snd = GameObject.Find("AudioSourceMining");
            AudioSource sndas = snd.GetComponent<AudioSource>();
            sndas.Stop();
            // Check if block has been restored to full health
            if (blockBeingMined_health>=BLOCK_MAX_HEALTH)
            {  // block restored to full health. No block is being mined anymore
                blockBeingMined_health = -1;
                blockBeingMined_xy = new IntVector2(-1, -1);
                gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }
        bBlockMinedThisFrame = false;	
	}

    // Mouse has been held down on a block
    public void MineBlock(IntVector2 bxy, GameObject block)
    {
        Debug.Log("MineBlock");
        if ((bxy.x == blockBeingMined_xy.x) && (bxy.y == blockBeingMined_xy.y))
        {  // Mouse is being held down on the block that is currently being mined
            //
            // Restart sound if it was stopped
            GameObject snd = GameObject.Find("AudioSourceMining");
            AudioSource sndas = snd.GetComponent<AudioSource>();
            if (!sndas.isPlaying)
                sndas.Play();
            // Reduce health of the block
            blockBeingMined_health -= 1;
            bBlockMinedThisFrame = true;
            if (blockBeingMined_health<=0)
            {  // Health is zero. block has been mined
               // Find "MakeWorld" script
                GameObject mwo = GameObject.Find("LoadLevel");
                MakeWorld mw = mwo.GetComponent<MakeWorld>();
                // Stop sound
                sndas.Stop();
                // SPAWN AN ITEM FROM THE MINED BLOCK
                // Find ItemManager
                GameObject im = GameObject.Find("ItemManager");
                ItemManagerScript ims = im.GetComponent<ItemManagerScript>();
                // TODO: Figure out which kind of block was mined
                // Spawn item
                ims.SpawnItem("dirt",block.transform.position);
                // Remove the block
                mw.RemoveBlock(block);
                // No block is being mined
                blockBeingMined_health = -1;
                blockBeingMined_xy = new IntVector2(-1, -1);
                bBlockMinedThisFrame = false;
                gameObject.transform.position = new Vector3(0, 0, 0);
            }
        }
        else
        {  // Mouse is being held down on a block that is NOT currently being mined
           // Find "MakeWorld" script
            GameObject mwo = GameObject.Find("LoadLevel");
            MakeWorld mw = mwo.GetComponent<MakeWorld>();
            // Update location of the mining icon
            Vector3 pos = mw.GetBlockPosition(bxy);
            gameObject.transform.position = new Vector3(pos.x, pos.y, -8.5f);
            // Reset block health and xy
            blockBeingMined_health = BLOCK_MAX_HEALTH;
            blockBeingMined_xy = bxy;
            bBlockMinedThisFrame = true;
            // Start sound
            GameObject snd = GameObject.Find("AudioSourceMining");
            AudioSource sndas = snd.GetComponent<AudioSource>();
            sndas.Play();
        }
    }
}
