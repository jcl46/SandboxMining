using UnityEngine;
using System.Collections;
using System;

public struct IntVector2
{
    public int x, y;
    public IntVector2(int bx,int by)
    {
        x = bx;
        y = by;
    }
}

    public class MakeWorld : MonoBehaviour {

    public int leveltoload = 0;
    public GameObject pl = null;
    private char[,] blockarray;
    private GameObject stone = null;
    private GameObject grass = null;
    private GameObject dirt = null;
    private GameObject template_block = null;
    public float blockwidth;
    public float blockheight;

	// Update is called once per frame
	void Update () {

    }

    void Start()
    {
        //        pl.transform.position = new Vector3(100, 100, 100);
        //        GameObject grass = (GameObject)Instantiate(Resources.Load(""));
        //GameObject grass = Instantiate();
        //grass.transform.position = new Vector3(3.7f, 0.5f, 0);
        //Instantiate(grass);        

        //        pl.transform.position = new Vector3(100, 100, 0);
        // Find block templates
        grass = GameObject.Find("grassTop-template");
        dirt = GameObject.Find("dirt-template");
        stone = GameObject.Find("Stone");
        template_block = GameObject.Find("dirt-template");
        // Find width/height
        blockwidth = grass.GetComponent<Renderer>().bounds.size.x;
        blockheight = grass.GetComponent<Renderer>().bounds.size.y;
        //        GenerateBlocksFromFile();
        CreateWorldArray(100, 30);
        GenerateBlocksFromArray();
        // Ignore collisions between player (layer 9) and items (layer 8)
        Physics2D.IgnoreLayerCollision(8, 9, true);
        // Ignore collisions between items (layer 8)
        Physics2D.IgnoreLayerCollision(8, 8, true);
    }

    private void GenerateBlocksFromArray()
    {
        // Find "ItemManager" script
        GameObject imo = GameObject.Find("ItemManager");
        ItemManagerScript ims = imo.GetComponent<ItemManagerScript>();
        for (int x = 0; x < blockarray.GetLength(0); x++)
        {
            for (int y = 0; y < blockarray.GetLength(1); y++)
            {
                GameObject go = null;
                char c = blockarray[x,y];
                string blockID = "";
                switch (c)
                {
                    case 'G': blockID = "grass";  break;
                    case 'S': break;
                    case 'D': blockID = "dirt";   break;
                    case 'U': blockID = "stone"; break;
                    default:
                        break;
                }
                if (blockID != "")
                {
                    go = Instantiate(template_block);
                    go.transform.position = new Vector3(x * blockwidth, -y * blockheight, -8);
                    go.GetComponent<SpriteRenderer>().sprite = ims.GetBlockSprite(blockID);
                }
            }
        }
    }

    private void GenerateBlocksFromFile()
    {
        // Create blocks
        //
        // Find "ItemManager" script
        GameObject imo = GameObject.Find("ItemManager");
        ItemManagerScript ims = imo.GetComponent<ItemManagerScript>();
        //
        string sFilename = "C:\\Users\\anton\\Desktop\\World1.txt";
        int linecounter = 0;
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader(sFilename);
        while ((line = file.ReadLine()) != null)
        {
            for (int i = 0; i < line.Length; i++)
            {
                GameObject go = null;
                char c = line[i];
                switch (c)
                {
                    case 'G': go = Instantiate(grass); break;
                    case 'S': go = null; break;
                    case 'D': go = Instantiate(dirt); break;
                    case 'U': go = Instantiate(stone); break;
                    default:
                        break;
                }
                if (go != null)
                {
                    go.transform.position = new Vector3(i * blockwidth,  - linecounter * blockheight, 0);                    
                    go.GetComponent<SpriteRenderer>().sprite = ims.GetBlockSprite("dirt");
                }
            }
            linecounter++;
        }
        file.Close();
    }

    private void CreateWorldArray(int iWidth, int iHeight)
    {
        blockarray = new char[iWidth, iHeight];
        int iCurrentHeight = iHeight/2;
        System.Random rnd = new System.Random();
        for (int x = 0; x < iWidth; x++)
        {
            // Update iCurrentHeight
            if (rnd.Next(4)==0)
            {   // Change height
                if (rnd.Next(3)>0)
                  iCurrentHeight += (rnd.Next(3) - 1);   // Shift max 1 block
                else
                  iCurrentHeight += (rnd.Next(5) - 2);   // Shift max 2 blocks
            }
            // 
            if (iCurrentHeight < 0)
                iCurrentHeight = 0;
            if (iCurrentHeight >= iHeight)
                iCurrentHeight = iHeight-1;
            //
            for (int y = 0; y < iHeight; y++)
            {
                if (y < iCurrentHeight)
                    blockarray[x, y] = 'S';
                else if (y == iCurrentHeight)
                    blockarray[x, y] = 'G';
                else
                    blockarray[x, y] = 'D';
            }

        }
    }

    // Get block index x,y from world coordinates
    public IntVector2 GetBlockIndexFromCoordinates(Vector3 blockpos)
    {
        IntVector2 r;
        r.x = Mathf.FloorToInt((blockpos.x + blockwidth / 2f) / blockwidth);
        r.y = -Mathf.FloorToInt((blockpos.y + blockheight / 2f) / blockheight);
        return r;
    }

    // Find block world coordinates from block index x,y
    public Vector3 GetBlockPosition(IntVector2 bxy)
    {
        Vector3 blockpos = new Vector3(bxy.x * blockwidth, -bxy.y * blockheight, -8);
        return blockpos;
    }

    // Remove a block
    public void RemoveBlock(GameObject goBlock)
    {
        IntVector2 bxy = GetBlockIndexFromCoordinates(goBlock.transform.position);
        blockarray[bxy.x, bxy.y] = 'S';
        Destroy(goBlock);
    }

    // Return true if block location is occupied
    public bool BlockSpaceOccupied(IntVector2 bxy)
    {
        return blockarray[bxy.x, bxy.y] != 'S';
    }

    // Place a block on block index bx,by
    // Only place block if location is not blocked
    // Only place block if block will not intersect the player
    public void PlaceBlock(IntVector2 bxy, char blocktype)
    {
        if (blockarray[bxy.x, bxy.y] == 'S')
        {  // Location is not blocked

            // Check if collides with the player
            GameObject pl = GameObject.Find("CharacterRobotBoy");
            Bounds plBounds = pl.GetComponent<Renderer>().bounds;
            plBounds.size = new Vector3(0.8f,1.6f,100f);    // DONT KNOW WHY THIS IS NEEDED
            Bounds blBounds = new Bounds();
            blBounds.center = GetBlockPosition(bxy);
            blBounds.extents = new Vector3(blockwidth / 2, blockheight / 2, 100);
            if (!plBounds.Intersects(blBounds))
            {   // Block will not intersect the player
                // Create gameobject
                GameObject go = null;
                switch (blocktype)
                {
                    case 'G': go = Instantiate(grass); break;
                    case 'S': go = null; break;
                    case 'D': go = Instantiate(dirt); break;
                    case 'U': go = Instantiate(stone); break;
                    default:
                        break;
                }
                if (go != null)
                {
                    go.transform.position = GetBlockPosition(bxy);
                    blockarray[bxy.x, bxy.y] = blocktype;
                }
            }
        }
    }

    // Find (approximate) distance from a block to the player
    public float DistanceBlockToPlayer(IntVector2 bxy)
    {
        GameObject pl = GameObject.Find("CharacterRobotBoy");
        Vector3 blockpos = GetBlockPosition(bxy);
        return Vector2.Distance(new Vector2(blockpos.x, blockpos.y), new Vector2(pl.transform.position.x, pl.transform.position.y));
    }

    // Find Block x,y at mouse position
    public IntVector2 GetBlockIndexAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        IntVector2 bxy = GetBlockIndexFromCoordinates(ray.origin);
        return bxy;
    }

}
