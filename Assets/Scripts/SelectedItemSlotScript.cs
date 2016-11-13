using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedItemSlotScript : MonoBehaviour {

    private int SelectedSlot = 1;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        int SelSlot = SelectedSlot;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SelectedSlot = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            SelectedSlot = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            SelectedSlot = 2;
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            SelectedSlot += 1;
            if (SelectedSlot>=10) SelectedSlot = 0;
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") <0)
        {
            SelectedSlot -= 1;
            if (SelectedSlot < 0) SelectedSlot = 9;
        }
        if (SelSlot != SelectedSlot)
        {
            // Set selected box location
            GameObject goBox = GameObject.Find("SelectedItemSlot");
            GameObject goSlot1 = GameObject.Find("Slot1");
            GameObject goSlot2 = GameObject.Find("Slot2");
            float width = goSlot2.transform.position.x-goSlot1.transform.position.x;
            goBox.transform.position = new Vector3(goSlot1.transform.position.x + width * SelectedSlot, goSlot1.transform.position.y, goSlot1.transform.position.z);
        }

    }
}
