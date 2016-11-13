using UnityEngine;
using System.Collections;

public class FloatingItemScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {  // Floating item collided with the player
           // Pick up item            
           // Add item to inventory
            GameObject inm = GameObject.Find("InventoryManager");
            InventoryManagerScript inms = inm.GetComponent<InventoryManagerScript>();
            if (inms.AddItemToInventory("dirt"))
            {  // Item added succesfully to inventory
               // Destroy the floating item
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }

}
