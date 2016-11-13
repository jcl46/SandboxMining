using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InventorySlotScript : MonoBehaviour, IPointerClickHandler {

    public int InventorySlotIndex = -1;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        Debug.Log("I was clicked");
        GameObject dadi = GameObject.Find("DragAndDropItem");
        DragAndDropItemScript dads = dadi.GetComponent<DragAndDropItemScript>();
        dads.InventorySlotClicked(InventorySlotIndex);
    }


}
