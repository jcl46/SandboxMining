using UnityEngine;
using System.Collections;

public class PlaceBlockScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(1))
        {  // Mouse right-click: Place a block
            // Find "MakeWorld" script
            GameObject mwo = GameObject.Find("LoadLevel");
            MakeWorld mw = mwo.GetComponent<MakeWorld>();
            // Find block index x,y
            IntVector2 bxy = mw.GetBlockIndexAtMouse();
            // Find player
            if (mw.DistanceBlockToPlayer(bxy) < 4)
            {  // Block is close to the player
                // Determine if a neigbour block is occupied
                bool bEmpty = !mw.BlockSpaceOccupied(new IntVector2(bxy.x - 1, bxy.y));
                bEmpty = bEmpty && !mw.BlockSpaceOccupied(new IntVector2(bxy.x + 1, bxy.y));
                bEmpty = bEmpty && !mw.BlockSpaceOccupied(new IntVector2(bxy.x, bxy.y-1));
                bEmpty = bEmpty && !mw.BlockSpaceOccupied(new IntVector2(bxy.x, bxy.y+1));
                if (!bEmpty)
                {
                    // Place block
                    mw.PlaceBlock(bxy, 'D');
                }
            }
        }

    }

}
